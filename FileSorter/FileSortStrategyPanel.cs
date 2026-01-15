namespace FileSorter
{
    public partial class FileSortStrategyPanel : FlowLayoutPanel
    {
        public MainView? mainView;
        public static String[] sortModeText = ["Erstelldatum", "Zuletzt geändert", "Jahr erstellt", "Jahr zuletzt geändert", "Dateiname bestehend aus"];
        private List<RadioButton> radioButtonGroup = new List<RadioButton>();
        private int selectedRadioButton = -1;
        public FileSortStrategyPanel()
        {
            InitializeComponent();
        }

        private void initComboBox(ComboBox comboBox)
        {
            foreach (String s in sortModeText)
            {
                comboBox.Items.Add(s);
            }
            comboBox.SelectedIndex = 0;
            mainView?.FileSortStrategyList.Add(new DateSortStrategy(FileSortDate.CreationDate));
        }

        public void addSortStrategy(object sender, EventArgs e)
        {
            if (mainView == null)
                return;
            int currentIndex = mainView.FileSortStrategyList.Count + 1;
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
            initComboBox(comboBoxNewFilter);

            //create edit button
            Button editValueButton = new Button();
            editValueButton.Text = "...";
            editValueButton.Size = new Size(25, 25);
            editValueButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editValueButton.ForeColor = Color.Gray;
            editValueButton.TextAlign = ContentAlignment.TopLeft;
            editValueButton.Click += new EventHandler(editValueBtnClicked);

            //createRadioButton
            RadioButton radioButton = new RadioButton();
            radioButton.Size = new Size(25, 25);
            radioButtonGroup.Add(radioButton);
            radioButton.CheckedChanged += new EventHandler(onRadioButtonClicked);

            //add all to panels
            newSortStrategyLayout.Size = new Size(260, 30);
            newSortStrategyLayout.Controls.Add(radioButton);
            newSortStrategyLayout.Controls.Add(removeButton);
            newSortStrategyLayout.Controls.Add(comboBoxNewFilter);
            newSortStrategyLayout.Controls.Add(editValueButton);
            Controls.Add(newSortStrategyLayout);

            comboBoxNewFilter.SelectedIndexChanged += onComboboxChanged; //at end to not invoke on init
        }

        private void editValueBtnClicked(object? sender, EventArgs e)
        {
            if (mainView == null)
                return;
            Button? editButton = sender as Button;
            if(editButton == null)
                return;
            int idx = Utils.getTagNumber(editButton) - 1;
            ComboBox comboBox = (ComboBox)editButton.Parent.Controls[2];
            FileNameSortDialog dialog = new FileNameSortDialog();
            FileSortStrategy current = mainView.FileSortStrategyList[idx];
            if(current != null && current.GetType() == typeof(FileNameSortStrategy))
            {
                FileNameSortStrategy strategy = (FileNameSortStrategy)current;
                dialog.Content = new FileNameSortDialog.FileNameSortDialogRes(strategy.fileNamePattern, strategy.folderNamePattern);
            }
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                FileNameSortDialog.FileNameSortDialogRes res = dialog.Content;
                mainView.FileSortStrategyList[idx] = new FileNameSortStrategy(res.fileName, res.folderName);
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
            Controls.RemoveAt(idx);
            if (radioButtonGroup[idx].Checked)
                selectedRadioButton = -1;
            if (selectedRadioButton > idx) // if radiobutton from item after the deleted one ist checked, its index decreases with one 
                selectedRadioButton -= 1;
            radioButtonGroup.RemoveAt(idx);
            mainView.FileSortStrategyList.RemoveAt(idx);
            //on remove, move tag and index in name
            for (int i = idx; i < Controls.Count; i++)
            {
                Control c = Controls[i];
                c.Tag = i + 1;
                c.Name = "layoutSortStrategy" + (i + 1);
            }
        }

        private void onRadioButtonClicked(object? sender, EventArgs e)
        {
            RadioButton? radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            if(radioButton.Checked)
            {
                for (int i = 0; i < radioButtonGroup.Count; i++)
                {
                    RadioButton rbtn = radioButtonGroup[i];
                    if (radioButton != rbtn)
                        rbtn.Checked = false;
                    else
                        selectedRadioButton = i;
                }
            }
        }

        private void onComboboxChanged(object? sender, EventArgs e)
        {
            if (mainView == null)
                return;
            ComboBox? comboBox = sender as ComboBox;
            if (comboBox == null)
                return;
            int idx = Utils.getTagNumber(comboBox) - 1;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    mainView.FileSortStrategyList[idx] = new DateSortStrategy(FileSortDate.CreationDate);
                    break;
                case 1:
                    mainView.FileSortStrategyList[idx] = new DateSortStrategy(FileSortDate.LastChangedDate);
                    break;
                case 2:
                    mainView.FileSortStrategyList[idx] = new YearSortStrategy(FileSortDate.CreationDate);
                    break;
                case 3:
                    mainView.FileSortStrategyList[idx] = new YearSortStrategy(FileSortDate.LastChangedDate);
                    break;
                case 4:
                    mainView.FileSortStrategyList[idx] = null;
                    break;
            }
        }

        public void moveUp()
        {
            if (mainView == null)
                return;
            if(selectedRadioButton > 0)
            {
                move(-1);
            }
        }

        public void moveDown()
        {
            if (mainView == null)
                return;
            if (selectedRadioButton < Controls.Count - 1 && selectedRadioButton > -1)
            {
                move(1);
            }
        }

        public void move(int direction)
        {
            //copy panels to array
            Control[] controls = new Control[Controls.Count];
            for (int i = 0; i < Controls.Count; i++)
            {
                controls[i] = Controls[i];
            }
            Controls.Clear();
            //switch tags
            object? tagTmp = controls[selectedRadioButton].Tag;
            controls[selectedRadioButton].Tag = controls[selectedRadioButton + direction].Tag;
            controls[selectedRadioButton + direction].Tag = tagTmp;
            // switch items
            Control controlTmp = controls[selectedRadioButton];
            controls[selectedRadioButton] = controls[selectedRadioButton + direction];
            controls[selectedRadioButton + direction] = controlTmp;
            // switch FileSortStrategy models
            List<FileSortStrategy> strategies = mainView.FileSortStrategyList;
            FileSortStrategy strategyTmp = strategies[selectedRadioButton];
            strategies[selectedRadioButton] = strategies[selectedRadioButton + direction];
            strategies[selectedRadioButton + direction] = strategyTmp;
            // switch radioButtons in list
            RadioButton radioButtonTmp = radioButtonGroup[selectedRadioButton];
            radioButtonGroup[selectedRadioButton] = radioButtonGroup[selectedRadioButton + direction];
            radioButtonGroup[selectedRadioButton + direction] = radioButtonTmp;
            //copy panels back
            Controls.AddRange(controls);
            selectedRadioButton += direction;
        }
    }
}
