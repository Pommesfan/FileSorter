using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorter
{
    public struct SizeFilterRes
    {
        public readonly int from;
        public readonly int until;
        public SizeFilterRes(int from, int until)
        {
            this.from = from;
            this.until = until;
        }
    }
    public partial class SizeFilterDialog : Form
    {
        public readonly String[] sizeUnitStrings = ["B", "kB", "MB", "GB"];
        private double sizeFrom;
        private double sizeUntil;
        public SizeFilterDialog()
        {
            InitializeComponent();
            foreach (String s in sizeUnitStrings)
            {
                comboBoxSizeFrom.Items.Add(s);
                comboBoxSizeUntil.Items.Add(s);
            }
            comboBoxSizeFrom.SelectedIndex = 0;
            comboBoxSizeUntil.SelectedIndex = 0;
        }

        private void checkBoxSizeFrom_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxSizeFrom.Checked;
            textBoxSizeFrom.Enabled = isChecked;
            comboBoxSizeFrom.Enabled = isChecked;
            checkBoxSizeUntil.Enabled = isChecked;
            if (isChecked)
            {
                processInput(comboBoxSizeFrom, textBoxSizeFrom, out sizeFrom);
            } else
            {
                processInput(comboBoxSizeUntil, textBoxSizeUntil, out sizeUntil);
            }
        }

        private void checkBoxSizeUntil_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxSizeUntil.Checked;
            textBoxSizeUntil.Enabled = isChecked;
            comboBoxSizeUntil.Enabled = isChecked;
            checkBoxSizeFrom.Enabled = isChecked;
            if (isChecked)
            {
                processInput(comboBoxSizeUntil, textBoxSizeUntil, out sizeUntil);
            } else
            {
                processInput(comboBoxSizeFrom, textBoxSizeFrom, out sizeFrom);
            }
        }

        private void textBoxSizeFrom_TextChanged(object sender, EventArgs e)
        {
            processInput(comboBoxSizeFrom, textBoxSizeFrom, out sizeFrom);
        }

        private void textBoxSizeUntil_TextChanged(object sender, EventArgs e)
        {
            processInput(comboBoxSizeUntil, textBoxSizeUntil, out sizeUntil);
        }

        private void processInput(ComboBox comboBox, TextBox textBox, out double output)
        {
            btnOk.Enabled = false;
            output = 0;
            String text = textBox.Text;
            if (text.Length == 0)
                return;

            // parse value
            //if type is byte, only accept values without comma
            if (comboBox.SelectedIndex == 0)
            {
                if (int.TryParse(text, out int sizeInt))
                {
                    output = sizeInt;
                }
                else
                {
                    MessageBox.Show("Ungültiger Wert für Größe");
                    return;
                }
            }
            //for other allow comma-values
            else if (!double.TryParse(text, out output))
            {
                MessageBox.Show("Ungültiger Wert für Größe");
                return;
            }

            // don't bring message of size relation false, when field is empty
            if (checkFieldEmpty())
                return;

            if (checkSizeNegative())
                return;

            if (!check_size_order())
                return;
            btnOk.Enabled = true;
        }

        private bool checkFieldEmpty()
        {
            return (checkBoxSizeFrom.Checked && textBoxSizeFrom.Text.Length == 0) ||
                (checkBoxSizeUntil.Checked && textBoxSizeUntil.Text.Length == 0);
        }

        private bool checkSizeNegative()
        {
            bool res = (checkBoxSizeFrom.Checked && sizeFrom < 0) || (checkBoxSizeUntil.Checked &&sizeUntil < 0);
            if (res)
                MessageBox.Show("Angaben müssen positiv sein");
            return res;
        }

        private bool check_size_order()
        {
            if (!checkBoxSizeFrom.Checked || !checkBoxSizeUntil.Checked)
                return true;

            bool res = absoluteSizeFrom() < absoluteSizeUntil();
            if(!res)
                MessageBox.Show("Größe von muss klein als Größe bis sein");
            return res;
        }

        private void comboBoxSizeUntil_SelectedIndexChanged(object sender, EventArgs e)
        {
            processInput(comboBoxSizeUntil, textBoxSizeUntil, out sizeUntil);
        }

        private void comboBoxSizeFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            processInput(comboBoxSizeFrom, textBoxSizeFrom, out sizeFrom);
        }

        private int absoluteSizeFrom()
        {
            int selection = comboBoxSizeFrom.SelectedIndex;
            return (int) (sizeFrom * Math.Pow(1024, selection));
        }
        private int absoluteSizeUntil()
        {
            int selection = comboBoxSizeUntil.SelectedIndex;
            return (int)(sizeUntil * Math.Pow(1024, selection));
        }

        public SizeFilterRes SizeSpan
        {
            get
            {
                if(!checkBoxSizeFrom.Checked)
                {
                    return new SizeFilterRes(-1, absoluteSizeUntil());
                } else if(!checkBoxSizeFrom.Checked)
                {
                    return new SizeFilterRes(absoluteSizeFrom(), -1);
                } else
                {
                    return new SizeFilterRes(absoluteSizeFrom(), absoluteSizeUntil());
                }
            }

            set
            {
                if(value.from == -1)
                {
                    checkBoxSizeFrom.Checked = false;
                    textBoxInsertSizeFrom.Enabled = false;
                    comboBoxSizeFrom.Enabled = false;
                } else
                {
                    sizeFrom = value.from;
                }

                if (value.until == -1)
                {
                    checkBoxSizeUntil.Checked = false;
                    textBoxInsertSizeUntil.Enabled = false;
                    comboBoxSizeUntil.Enabled = false;
                }
                else
                {
                    sizeUntil = value.until;
                }
            }
        }
    }
}
