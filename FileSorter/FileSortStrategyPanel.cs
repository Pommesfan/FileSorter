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
    public partial class FileSortStrategyPanel : FlowLayoutPanel
    {
        public FileSortStrategyPanel()
        {
            InitializeComponent();
        }

        private void addSortStrategy(object sender, EventArgs e)
        {
            int currentIndex = Controls.Count + 1;
            //create panel
            FlowLayoutPanel newSortStrategyLayout = new FlowLayoutPanel();
            newSortStrategyLayout.Name = "layoutSortStrategy" + currentIndex;
            newSortStrategyLayout.Tag = currentIndex;
            newSortStrategyLayout.FlowDirection = FlowDirection.LeftToRight;

            //create remove button
            Button removeButton = new Button();
            removeButton.Text = "x";
            removeButton.Size = new Size(25, 25);
            removeButton.BackColor = Color.Red;
            removeButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            removeButton.ForeColor = Color.White;
            removeButton.TextAlign = ContentAlignment.TopLeft;
            removeButton.Click += onRemove;

            //create combobox
            ComboBox comboBoxNewFilter = new ComboBox();
            comboBoxNewFilter.Size = new Size(160, 25);
            comboBoxNewFilter.DropDownStyle = ComboBoxStyle.DropDownList;

            //create edit button
            Button editValueButton = new Button();
            editValueButton.Text = "...";
            editValueButton.Size = new Size(25, 25);
            editValueButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editValueButton.ForeColor = Color.Gray;
            editValueButton.TextAlign = ContentAlignment.TopLeft;

            //add all to panels
            newSortStrategyLayout.Size = new Size(260, 30);
            newSortStrategyLayout.Controls.Add(removeButton);
            newSortStrategyLayout.Controls.Add(comboBoxNewFilter);
            newSortStrategyLayout.Controls.Add(editValueButton);
            Controls.Add(newSortStrategyLayout);
        }

        private void onRemove(object? sender, EventArgs e)
        {
            Button removeButton = sender as Button;
            int idx = ((int)removeButton.Parent.Tag) - 1;
            Controls.RemoveAt(idx);
            //on remove, move tag and index in name
            for (int i = idx; i < Controls.Count; i++)
            {
                Control c = Controls[i];
                c.Tag = i + 1;
                c.Name = "layoutSortStrategy" + (i + 1);
            }
        }
    }
}
