using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorter
{
    public class FileFilterPanel: FlowLayoutPanel
    {
        public static String[] filterModeText = ["Dateityp", "Erstellt", "Geändert", "Name beinhaltet", "Name beginnt mit"];
        private List<FileFilter> fileFilters = new();

        private void initFilterModes(ComboBox comboBox)
        {
            foreach (String mode in filterModeText)
            {
                comboBox.Items.Add(mode);
            }
        }

        public void addFilter()
        {
            int currentIndex = Controls.Count + 1;
            //create panel
            FlowLayoutPanel newFlowLayoutPanel = new FlowLayoutPanel();
            newFlowLayoutPanel.Name = "layoutFilter" + currentIndex;
            newFlowLayoutPanel.Tag = currentIndex;
            newFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

            //create combobox
            ComboBox comboBoxNewFilter = new ComboBox();
            comboBoxNewFilter.Size = new Size(146, 25);
            initFilterModes(comboBoxNewFilter);

            //create textbox
            TextBox filterArgs = new TextBox();
            filterArgs.Size = new Size(135, 25);

            //create remove button
            Button removeButton = new Button();
            removeButton.Text = "-";
            removeButton.Size = new Size(25, 25);
            removeButton.BackColor = Color.Red;
            removeButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            removeButton.ForeColor = Color.White;
            removeButton.TextAlign = ContentAlignment.TopLeft;

            //add all to panels
            newFlowLayoutPanel.Size = new Size(333, 30);
            newFlowLayoutPanel.Controls.Add(comboBoxNewFilter);
            newFlowLayoutPanel.Controls.Add(filterArgs);
            newFlowLayoutPanel.Controls.Add(removeButton);
            Controls.Add(newFlowLayoutPanel);

            //reaction to select filter mode
            comboBoxNewFilter.SelectedIndexChanged += new EventHandler(onFilterChanged);
            filterArgs.TextChanged += new EventHandler(onFilterChanged);
            removeButton.Click += new EventHandler(onRemove);

            fileFilters.Add(null);
        }

        private void onRemove(object? sender, EventArgs e)
        {
            Button removeButton = sender as Button;
            int idx = ((int)removeButton.Parent.Tag) - 1;
            fileFilters.RemoveAt(idx);
            Controls.RemoveAt(idx);
            //on remove, move tag and index in name
            for (int i = idx; i < Controls.Count; i++)
            {
                Control c = Controls[i];
                c.Tag = i + 1;
                c.Name = "layoutFilter" + (i + 1);
            }
        }

        private void onFilterChanged(object? sender, EventArgs e)
        {
            Control c = sender as Control;
            if (c == null)
                throw new ArgumentException("argument sender is no object of Control");
            Control parent = c.Parent;

            int idx = ((int)parent.Tag) - 1;
            ComboBox comboBoxFilter = (ComboBox)parent.Controls[0];
            TextBox filterArgs = (TextBox)parent.Controls[1];
            String argument = filterArgs.Text;
            FileFilter fileFilter;
            switch (comboBoxFilter.SelectedIndex)
            {
                case 0:
                    fileFilter = new ExtensionFilter(argument);
                    break;
                case 3:
                    fileFilter = new NameContentsFilter(argument);
                    break;
                case 4:
                    fileFilter = new NameStartFilter(argument);
                    break;
                default:
                    fileFilter = null;
                    break;
            }
            fileFilters[idx] = fileFilter;
        }

        public int Count {
            get { return fileFilters.Count; }
        }

        public FileFilter this[int idx]
        {
            get { return fileFilters[idx]; }
        }
    }
}
