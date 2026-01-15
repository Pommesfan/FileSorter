namespace FileSorter
{
    public partial class FileSortStrategyPanel : FlowLayoutPanel
    {
        public MainView? mainView;
        public static String[] sortModeText = ["Erstelldatum", "Zuletzt geändert", "Jahr erstellt", "Jahr zuletzt geändert"];
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
            mainView.FileSortStrategyList.Add(new DateSortStrategy(FileSortDate.CreationDate));
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

            //add all to panels
            newSortStrategyLayout.Size = new Size(260, 30);
            newSortStrategyLayout.Controls.Add(removeButton);
            newSortStrategyLayout.Controls.Add(comboBoxNewFilter);
            newSortStrategyLayout.Controls.Add(editValueButton);
            Controls.Add(newSortStrategyLayout);

            comboBoxNewFilter.SelectedIndexChanged += onComboboxChanged; //at end to not invoke on init
        }

        private void onRemove(object? sender, EventArgs e)
        {
            if (mainView == null)
                return;
            Button removeButton = sender as Button;
            if (removeButton == null)
                return;
            int idx = Utils.getTagNumber(removeButton) - 1;
            Controls.RemoveAt(idx);
            mainView.FileSortStrategyList.RemoveAt(idx);
            //on remove, move tag and index in name
            for (int i = idx; i < Controls.Count; i++)
            {
                Control c = Controls[i];
                c.Tag = i + 1;
                c.Name = "layoutSortStrategy" + (i + 1);
            }
        }

        private void onComboboxChanged(object? sender, EventArgs e)
        {
            if (mainView == null)
                return;
            ComboBox comboBox = sender as ComboBox;
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
            }
        }
    }
}
