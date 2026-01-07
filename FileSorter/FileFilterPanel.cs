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
            newFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

            //create combobox
            ComboBox comboBoxNewFilter = new ComboBox();
            comboBoxNewFilter.Size = new Size(146, 23);
            comboBoxNewFilter.Name = "comboboxFilter" + currentIndex;
            comboBoxNewFilter.Tag = currentIndex;
            initFilterModes(comboBoxNewFilter);

            //create textbox
            TextBox filterArgs = new TextBox();
            filterArgs.Name = "textBoxFilterArgs" + currentIndex;
            filterArgs.Size = new Size(135, 23);
            filterArgs.Tag = currentIndex;

            //add all to panels
            newFlowLayoutPanel.Size = new Size(303, 30);
            newFlowLayoutPanel.Controls.Add(comboBoxNewFilter);
            newFlowLayoutPanel.Controls.Add(filterArgs);
            Controls.Add(newFlowLayoutPanel);

            //reaction to select filter mode
            comboBoxNewFilter.SelectedIndexChanged += new EventHandler(onFilterChanged);
            filterArgs.TextChanged += new EventHandler(onFilterChanged);

            fileFilters.Add(null);
        }

        private void onFilterChanged(object? sender, EventArgs e)
        {
            Control c = sender as Control;
            if (c == null)
                throw new ArgumentException("argument sender is no object of Control");
            int idx = ((int)c.Tag) - 1;
            FlowLayoutPanel layout = (FlowLayoutPanel)Controls[idx];
            ComboBox comboBoxFilter = (ComboBox)layout.Controls[0];
            TextBox filterArgs = (TextBox)layout.Controls[1];
            String argument = filterArgs.Text;
            FileFilter fileFilter;
            switch (comboBoxFilter.SelectedIndex)
            {
                case 1:
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
