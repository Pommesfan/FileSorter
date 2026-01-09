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
            comboBoxNewFilter.Size = new Size(160, 25);
            initFilterModes(comboBoxNewFilter);

            //create edit button
            Button editValueButton = new Button();
            editValueButton.Text = "...";
            editValueButton.Size = new Size(25, 25);
            editValueButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editValueButton.ForeColor = Color.Gray;
            editValueButton.TextAlign = ContentAlignment.TopLeft;

            //add all to panels
            newFlowLayoutPanel.Size = new Size(260, 30);
            newFlowLayoutPanel.Controls.Add(removeButton);
            newFlowLayoutPanel.Controls.Add(comboBoxNewFilter);
            newFlowLayoutPanel.Controls.Add(editValueButton);
            Controls.Add(newFlowLayoutPanel);

            //reaction to select filter mode
            comboBoxNewFilter.SelectedIndexChanged += new EventHandler(onComboboxValueChanged);
            editValueButton.Click += new EventHandler(onValueChangeClicked);
            removeButton.Click += new EventHandler(onRemove);

            fileFilters.Add(null);
        }

        private void onComboboxValueChanged(object? sender, EventArgs e)
        {
            //when moving from DateSpanFilter to FileNameFilter or opposite, drop the selected information
            ComboBox combobox = (ComboBox)sender;
            int idx = (int)combobox.Parent.Tag - 1;
            int selection = combobox.SelectedIndex;
            if (selection == 1 || selection == 2)
            {
                if(fileFilters[idx] is DateSpanFilter)
                {
                    DateSpanFilter dateSpanFilter = (DateSpanFilter)fileFilters[idx];
                    switch(selection)
                    {
                        case 1:
                            fileFilters[idx] = new DateSpanFilter(dateSpanFilter.from, dateSpanFilter.until, FilterMode.CreationDate);
                            break;
                        case 2:
                            fileFilters[idx] = new DateSpanFilter(dateSpanFilter.from, dateSpanFilter.until, FilterMode.LastChangedDate);
                            break;
                    }

                } else
                {
                    fileFilters[idx] = null;
                }
            }
            else if (selection == 0 || selection == 3 || selection == 4)
            {
                if(fileFilters[idx] is FileNameFilter) {
                    FileNameFilter fileNameFilter = (FileNameFilter)fileFilters[idx];
                    switch (selection)
                    {
                        case 0:
                            fileFilters[idx] = new ExtensionFilter(fileNameFilter.possibleKeyWords);
                            break;
                        case 3:
                            fileFilters[idx] = new NameContentsFilter(fileNameFilter.possibleKeyWords);
                            break;
                        case 4:
                            fileFilters[idx] = new NameStartFilter(fileNameFilter.possibleKeyWords);
                            break;
                    }
                } else
                {
                    fileFilters[idx] = null;
                }
            }
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
                    setKeywordFilter(idx, FilterMode.Extension);
                    break;
                case 1:
                    setDateFilter(idx, FilterMode.CreationDate);
                    break;
                case 2:
                    setDateFilter(idx, FilterMode.LastChangedDate);
                    break;
                case 3:
                    setKeywordFilter(idx, FilterMode.Contains);
                    break;
                case 4:
                    setKeywordFilter(idx, FilterMode.StartsWith);
                    break;
            }
        }

        private void setKeywordFilter(int idx, FilterMode mode)
        {
            KeyWordsDialog dialog = new KeyWordsDialog();
            dialog.Owner = (Form)Parent;
            FileFilter current = fileFilters[idx];
            if (current != null)
            {
                FileNameFilter filter = (FileNameFilter)current;
                dialog.Content = filter.possibleKeyWords;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
                switch (mode)
                {
                    case FilterMode.Extension:
                        fileFilters[idx] = new ExtensionFilter(dialog.Content);
                        break;
                    case FilterMode.Contains:
                        fileFilters[idx] = new NameContentsFilter(dialog.Content);
                        break;
                    case FilterMode.StartsWith:
                        fileFilters[idx] = new NameStartFilter(dialog.Content);
                        break;
                }
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
