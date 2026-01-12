namespace FileSorter
{
    public struct SizeFilterRes
    {
        public readonly double from;
        public readonly double until;
        public readonly int sizeUnitFrom;
        public readonly int sizeUnitUntil;
        public SizeFilterRes(double from, double until, int sizeUnitFrom, int sizeUnitUntil)
        {
            this.from = from;
            this.until = until;
            this.sizeUnitFrom = sizeUnitFrom;
            this.sizeUnitUntil = sizeUnitUntil;
        }
        public long absoluteSizeFrom()
        {
            return (long)(from * Math.Pow(1024, sizeUnitFrom));
        }
        public long absoluteSizeUntil()
        {
            return (long)(until * Math.Pow(1024, sizeUnitUntil));
        }
    }

    public partial class SizeFilterDialog : Form
    {
        private double sizeFrom = -1;
        private double sizeUntil = -1;
        public readonly String[] sizeUnitStrings = ["B", "kB", "MB", "GB"];
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
        }

        private void checkBoxSizeUntil_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxSizeUntil.Checked;
            textBoxSizeUntil.Enabled = isChecked;
            comboBoxSizeUntil.Enabled = isChecked;
            checkBoxSizeFrom.Enabled = isChecked;
        }

        private bool processInput()
        {
            if (checkBoxSizeFrom.Checked && !parseInput(comboBoxSizeFrom, textBoxSizeFrom, out sizeFrom))
                return false;

            if (checkBoxSizeUntil.Checked && !parseInput(comboBoxSizeUntil, textBoxSizeUntil, out sizeUntil))
                return false;

            // don't bring message of size relation false, when field is empty
            if (checkFieldEmpty())
                return false;

            if (checkSizeNegative())
                return false;

            if (!check_size_order())
                return false;

            return true;
        }

        private bool parseInput(ComboBox comboBox, TextBox textBox, out double output)
        {
            output = 0;
            String text = textBox.Text;
            if (text.Length == 0)
            {
                return false;
            }

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
                    return false;
                }
            }
            //for other allow comma-values
            else if (!double.TryParse(text.Replace(".", ","), out output))
            {
                MessageBox.Show("Ungültiger Wert für Größe");
                return false;
            }
            return true;
        }

        private bool checkFieldEmpty()
        {
            return (checkBoxSizeFrom.Checked && textBoxSizeFrom.Text.Length == 0) ||
                (checkBoxSizeUntil.Checked && textBoxSizeUntil.Text.Length == 0);
        }

        private bool checkSizeNegative()
        {
            bool res = (checkBoxSizeFrom.Checked && sizeFrom < 0) || (checkBoxSizeUntil.Checked && sizeUntil < 0);
            if (res)
                MessageBox.Show("Angaben müssen positiv sein");
            return res;
        }

        private bool check_size_order()
        {
            if (!checkBoxSizeFrom.Checked || !checkBoxSizeUntil.Checked)
                return true;

            SizeFilterRes sizeFilterRes = new SizeFilterRes(sizeFrom, sizeUntil, comboBoxSizeFrom.SelectedIndex, comboBoxSizeUntil.SelectedIndex);
            bool res = sizeFilterRes.absoluteSizeFrom() < sizeFilterRes.absoluteSizeUntil();
            if (!res)
                MessageBox.Show("Größe von muss klein als Größe bis sein");
            return res;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            if (!processInput())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        public SizeFilterRes SizeSpan
        {
            get
            {
                if (!checkBoxSizeFrom.Checked)
                {
                    return new SizeFilterRes(-1, sizeUntil, -1, comboBoxSizeUntil.SelectedIndex);

                }
                else if (!checkBoxSizeUntil.Checked)
                {
                    return new SizeFilterRes(sizeFrom, -1, comboBoxSizeFrom.SelectedIndex, -1);
                }
                else
                {
                    return new SizeFilterRes(sizeFrom, sizeUntil, comboBoxSizeFrom.SelectedIndex, comboBoxSizeUntil.SelectedIndex);
                }
            }

            set
            {
                if (value.from == -1)
                {
                    checkBoxSizeFrom.Checked = false;
                    textBoxInsertSizeFrom.Enabled = false;
                    comboBoxSizeFrom.Enabled = false;
                }
                else
                {
                    comboBoxSizeFrom.SelectedIndex = value.sizeUnitFrom;
                    textBoxSizeFrom.Text = value.from.ToString();
                }

                if (value.until == -1)
                {
                    checkBoxSizeUntil.Checked = false;
                    textBoxInsertSizeUntil.Enabled = false;
                    comboBoxSizeUntil.Enabled = false;
                }
                else
                {
                    comboBoxSizeUntil.SelectedIndex = value.sizeUnitUntil;
                    textBoxSizeUntil.Text = value.until.ToString();
                }
            }
        }
    }
}
