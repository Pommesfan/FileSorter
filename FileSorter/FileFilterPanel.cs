namespace FileSorter
{
    public partial class FileFilterPanel : FlowLayoutPanel
    {
        public MainView? mainView;
        public static String[] filterModeText = ["Erstellt", "Geändert", "Dateityp", "Name beinhaltet", "Name beginnt mit", "Dateityp ist nicht", "Name beinhaltet nicht", "Name beginnt nicht mit", "Dateigröße"];
        public FileFilterPanel()
        {
            InitializeComponent();
        }
        private void initFilterModes(ComboBox comboBox)
        {
            foreach (String mode in filterModeText)
            {
                comboBox.Items.Add(mode);
            }
        }

        public void addFilter()
        {
            if (mainView == null)
                return;
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
            comboBoxNewFilter.DropDownStyle = ComboBoxStyle.DropDownList;
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

            mainView.FileFilterList.Add(null);
        }

        private void onComboboxValueChanged(object? sender, EventArgs e)
        {
            //when moving from DateSpanFilter to FileNameFilter or opposite, drop the selected information
            ComboBox? combobox = sender as ComboBox;
            if (mainView == null || combobox == null)
                return;
            int idx = Utils.getTagNumber(combobox) - 1;
            int selection = combobox.SelectedIndex;
            List<FileFilter> fileFilters = mainView.FileFilterList;
            if (selection == 1 || selection == 2)
            {
                if (fileFilters[idx] is DateSpanFilter)
                {
                    DateSpanFilter dateSpanFilter = (DateSpanFilter)fileFilters[idx];
                    switch (selection)
                    {
                        case 0:
                            fileFilters[idx] = new DateSpanFilter(dateSpanFilter.from, dateSpanFilter.until, FilterMode.CreationDate);
                            break;
                        case 1:
                            fileFilters[idx] = new DateSpanFilter(dateSpanFilter.from, dateSpanFilter.until, FilterMode.LastChangedDate);
                            break;
                    }

                }
                else
                {
                    fileFilters[idx] = null;
                }
            }
            else if (selection >= 2 && selection <= 7)
            {
                if (fileFilters[idx] is FileNameFilter)
                {
                    FileNameFilter fileNameFilter = (FileNameFilter)fileFilters[idx];
                    switch (selection)
                    {
                        case 2:
                            fileFilters[idx] = new ExtensionFilter(fileNameFilter.possibleKeyWords, false);
                            break;
                        case 3:
                            fileFilters[idx] = new NameContentsFilter(fileNameFilter.possibleKeyWords, false);
                            break;
                        case 4:
                            fileFilters[idx] = new NameStartFilter(fileNameFilter.possibleKeyWords, false);
                            break;
                        case 5:
                            fileFilters[idx] = new ExtensionFilter(fileNameFilter.possibleKeyWords, true);
                            break;
                        case 6:
                            fileFilters[idx] = new NameContentsFilter(fileNameFilter.possibleKeyWords, true);
                            break;
                        case 7:
                            fileFilters[idx] = new NameStartFilter(fileNameFilter.possibleKeyWords, true);
                            break;
                    }
                }
                else
                {
                    fileFilters[idx] = null;
                }
            }
        }

        private void onRemove(object? sender, EventArgs e)
        {
            if (mainView == null)
                return;
            Button? removeButton = sender as Button;
            if (removeButton == null)
                return;
            int idx = Utils.getTagNumber(removeButton) - 1;
            mainView.FileFilterList.RemoveAt(idx);
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
            if (mainView == null)
                return;
            Control control = (Control)sender;
            FlowLayoutPanel currentLayout = (FlowLayoutPanel)(control.Parent);
            ComboBox comboBox = (ComboBox)currentLayout.Controls[1];
            int idx = Utils.getTagNumber(control) - 1;
            int selectedMode = comboBox.SelectedIndex;
            if (selectedMode < 0)
                return;
            FilterMode mode = (FilterMode)selectedMode;
            if (selectedMode < 2)
            {
                setDateFilter(idx, mode);
            }
            else if (selectedMode < 8)
            {
                setKeywordFilter(idx, mode);
            }
            else if (selectedMode == 8)
            {
                setSizeFilter(idx);
            }
        }

        private void setKeywordFilter(int idx, FilterMode mode)
        {
            List<FileFilter> fileFilters = mainView.FileFilterList;
            KeyWordsDialog dialog = new KeyWordsDialog();
            dialog.Text = filterModeText[(int)mode];
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
                        fileFilters[idx] = new ExtensionFilter(dialog.Content, false);
                        break;
                    case FilterMode.Contains:
                        fileFilters[idx] = new NameContentsFilter(dialog.Content, false);
                        break;
                    case FilterMode.StartsWith:
                        fileFilters[idx] = new NameStartFilter(dialog.Content, false);
                        break;
                    case FilterMode.NotExtension:
                        fileFilters[idx] = new ExtensionFilter(dialog.Content, true);
                        break;
                    case FilterMode.NotContains:
                        fileFilters[idx] = new NameContentsFilter(dialog.Content, true);
                        break;
                    case FilterMode.NotStartsWith:
                        fileFilters[idx] = new NameStartFilter(dialog.Content, true);
                        break;
                }
        }

        private void setDateFilter(int idx, FilterMode mode)
        {
            DateFilterDialog dialog = new DateFilterDialog();
            FileFilter currentFilter = mainView.FileFilterList[idx];
            if (currentFilter != null && currentFilter.GetType() == typeof(DateSpanFilter))
            {
                DateSpanFilter filter = (DateSpanFilter)currentFilter;
                dialog.DateSpan = new DateFilterDialog.DateFilterRes(filter.from, filter.until);
            }
            dialog.Text = filterModeText[(int)mode];
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                mainView.FileFilterList[idx] = new DateSpanFilter(dialog.DateSpan.from, dialog.DateSpan.until, mode);
            }
        }

        private void setSizeFilter(int idx)
        {
            SizeFilterDialog dialog = new SizeFilterDialog();
            FileFilter currentFilter = mainView.FileFilterList[idx];
            if (currentFilter != null && currentFilter is SizeFilter)
            {
                SizeFilter filter = (SizeFilter)currentFilter;
                dialog.SizeSpan = filter.sizeFilterRes;
            }
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                SizeFilterRes sizeFilterRes = dialog.SizeSpan;
                mainView.FileFilterList[idx] = new SizeFilter(sizeFilterRes);
            }
        }
    }
}
