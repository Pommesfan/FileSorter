using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorter
{
    public partial class DateFilterDialog : Form
    {
        public struct DateFilterRes
        {
            public readonly DateTime? from;
            public readonly DateTime? until;
            public DateFilterRes(DateTime? from, DateTime? until)
            {
                this.from = from;
                this.until = until;
            }
        }
        public DateFilterDialog()
        {
            InitializeComponent();
            dateFrom.Value = DateTime.Now;
            dateUntil.Value = DateTime.Now;
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            dateUntil.MinDate = dateFrom.Value;
        }

        private void dateUntil_ValueChanged(object sender, EventArgs e)
        {
            dateFrom.MaxDate = dateUntil.Value;
        }
        private void checkBoxFrom_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxFrom.Checked;
            checkBoxUntil.Enabled = isChecked;
            dateFrom.Enabled = isChecked;
            if (isChecked)
            {
                dateUntil.MinDate = dateFrom.Value;
            }
            else
            {
                dateUntil.MinDate = DateTimePicker.MinimumDateTime;
            }
        }

        private void checkBoxUntil_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBoxUntil.Checked;
            checkBoxFrom.Enabled = isChecked;
            dateUntil.Enabled = isChecked;
            if(isChecked)
            {
                dateFrom.MaxDate = dateUntil.Value;
            } else
            {
                dateFrom.MaxDate = DateTimePicker.MaximumDateTime;
            }
        }

        public DateFilterRes DateSpan
        {
            get
            {
                if (!checkBoxFrom.Checked)
                {
                    return new DateFilterRes(null, dateUntil.Value);
                }
                else if (!checkBoxUntil.Checked)
                {
                    return new DateFilterRes(dateFrom.Value, null);
                }
                else
                {
                    return new DateFilterRes(dateFrom.Value, dateUntil.Value);
                }
            }
        }
    }
}
