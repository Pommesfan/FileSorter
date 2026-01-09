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
            if (!string.IsNullOrEmpty(textBoxKeyword.Text))
                listBoxKeywords.Items.Add(textBoxKeyword.Text);
            textBoxKeyword.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int idx = listBoxKeywords.SelectedIndex;
            if (idx == -1)
                return;
            listBoxKeywords.Items.RemoveAt(idx);
            int new_idx = idx - 1;
            if(new_idx != -1)
                listBoxKeywords.SelectedIndex = new_idx;
            else if(listBoxKeywords.Items.Count > 0)
                listBoxKeywords.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
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
