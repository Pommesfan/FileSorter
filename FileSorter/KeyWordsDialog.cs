namespace FileSorter
{
    public partial class KeyWordsDialog : Form
    {
        public KeyWordsDialog()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxKeyword.Text))
                listBoxKeywords.Items.Add(textBoxKeyword.Text);
            textBoxKeyword.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            listBoxKeywords.Items.RemoveAt(listBoxKeywords.SelectedIndex);
        }

        public String[] Content
        {
            get
            {
                int count = listBoxKeywords.Items.Count;
                String[] result = new String[count];
                for (int i = 0; i < count; i++)
                {
                    result[i] = listBoxKeywords.Items[i].ToString();
                }
                return result;
            }
            set
            {
                foreach (String item in value)
                {
                    listBoxKeywords.Items.Add(item);
                }
            }
        }
    }
}
