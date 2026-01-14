namespace FileSorter
{
    public partial class SortPreview : Form
    {
        public SortPreview()
        {
            InitializeComponent();
        }

        public TreeNode addFolder(String name)
        {

            TreeNode res = new TreeNode(name);
            treeViewSorted.Nodes.Add(res);
            return res;
        }

        public void addItem(String folder, String name)
        {
            TreeNode res = getNodeFromName(treeViewSorted.Nodes, folder);
            if (res == null)
                res = addFolder(folder);
            res.Nodes.Add(new TreeNode(name));
        }

        private TreeNode getNodeFromName(TreeNodeCollection nodes, String name)
        {
            TreeNode[]res = nodes.Cast<TreeNode>().Where(item => item.Text == name).ToArray();
            if(res.Length == 0)
                return null;
            else
                return res[0];
        }

        public void addSortedOutFile(String name)
        {
            listBoxFilteredOutItems.Items.Add(name);
        }
    }
}
