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

            //create remove button
            Button removeButton = new Button();
            removeButton.Text = "x";
            removeButton.Size = new Size(25, 25);
            removeButton.BackColor = Color.Red;
            removeButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            removeButton.ForeColor = Color.White;
            removeButton.TextAlign = ContentAlignment.TopLeft;

            //create combobox
            ComboBox comboBoxNewFilter = new ComboBox();
            comboBoxNewFilter.Size = new Size(146, 25);
            initFilterModes(comboBoxNewFilter);

            //create remove button
            Button editValueButton = new Button();
            editValueButton.Text = "...";
            editValueButton.Size = new Size(25, 25);
            editValueButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editValueButton.ForeColor = Color.Gray;
            editValueButton.TextAlign = ContentAlignment.TopLeft;

            //create textbox
            //TextBox filterArgs = new TextBox();
            //filterArgs.Size = new Size(135, 25);

            //add all to panels
            newFlowLayoutPanel.Size = new Size(333, 30);
            newFlowLayoutPanel.Controls.Add(removeButton);
            newFlowLayoutPanel.Controls.Add(comboBoxNewFilter);
            newFlowLayoutPanel.Controls.Add(editValueButton);
            //newFlowLayoutPanel.Controls.Add(filterArgs);
            Controls.Add(newFlowLayoutPanel);

            //reaction to select filter mode
            editValueButton.Click += new EventHandler(onValueChangeClicked);
            //filterArgs.TextChanged += new EventHandler(onFilterChanged);
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

        private void onValueChangeClicked(object sender, EventArgs e)
        {
            FlowLayoutPanel currentLayout = (FlowLayoutPanel)(((Control)sender).Parent);
            ComboBox comboBox = (ComboBox)currentLayout.Controls[1];
            int idx = (int)currentLayout.Tag - 1;
            int selectedMode = comboBox.SelectedIndex;
            if (selectedMode < 0)
                return;
            switch(selectedMode)
            {
                case 0:
                    setExtensionFilter(idx);
                    break;
                case 1:
                    setDateFilter(idx, FilterMode.CreationDate);
                    break;
                case 2:
                    setDateFilter(idx, FilterMode.LastChangedDate);
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        private void setExtensionFilter(int idx)
        {
            KeyWordsDialog dialog = new KeyWordsDialog();
            dialog.Owner = (Form)Parent;
            FileFilter current = fileFilters[idx];
            if (current != null)
                dialog.Content = ((ExtensionFilter)current).extensions;
            if (dialog.ShowDialog() == DialogResult.OK)
                fileFilters[idx] = new ExtensionFilter(dialog.Content);
        }

        private void setDateFilter(int idx, FilterMode mode)
        {
            DateFilterDialog dialog = new DateFilterDialog();
            dialog.Owner = (Form)Parent;
            FileFilter currentFilter = fileFilters[idx];
            if (currentFilter != null && currentFilter.GetType() == typeof(DateSpanFilter))
            {
                DateSpanFilter filter = (DateSpanFilter)currentFilter;
                dialog.DateSpan = new DateFilterDialog.DateFilterRes(filter.from, filter.until);
            }
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                fileFilters[idx] = new DateSpanFilter(dialog.DateSpan.from, dialog.DateSpan.until, mode);
            }
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
