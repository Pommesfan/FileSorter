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
            return addFolder(name, treeViewSorted.Nodes);
        }

        public TreeNode addFolder(String name, TreeNodeCollection current)
        {
            String[] folderNames = name.Split("\\", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < folderNames.Length - 1; i++)
            {
                current = getNodeFromName(current, folderNames[i]).Nodes;
            }

            TreeNode res = new TreeNode(folderNames.Last());
            current.Add(res);
            return res;
        }

        public void addItem(String folder, String name)
        {
            String[] folderNames = folder.Split("\\", StringSplitOptions.RemoveEmptyEntries);
            TreeNodeCollection current = treeViewSorted.Nodes;
            for (int i = 0; i < folderNames.Length; i++)
            {
                TreeNode next = getNodeFromName(current, folderNames[i]);
                if (next == null)
                    current = addFolder(folderNames[i], current).Nodes;
                else
                    current = next.Nodes;
            }
            current.Add(new TreeNode(name));
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
