namespace FileSorter
{
    public partial class SortPreview : Form
    {
        public SortPreview()
        {
            InitializeComponent();
        }

        private TreeNode addFolderToTreeView(String name, TreeNodeCollection current)
        {
            TreeNode res = new TreeNode(name);
            current.Add(res);
            return res;
        }

        private void addItemToTreeView(String folder, String name, TreeNodeCollection current)
        {
            String[] folderNames = folder.Split("\\", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < folderNames.Length; i++)
            {
                TreeNode? next = getNodeFromName(current, folderNames[i]);
                if (next == null)
                    current = addFolderToTreeView(folderNames[i], current).Nodes;
                else
                    current = next.Nodes;
            }
            current.Add(new TreeNode(name));
        }
        public void addItem(String folder, String name)
        {
            addItemToTreeView(folder, name, treeViewSorted.Nodes);
        }

        private TreeNode? getNodeFromName(TreeNodeCollection nodes, String name)
        {
            TreeNode[]res = nodes.Cast<TreeNode>().Where(item => item.Text == name).ToArray();
            if(res.Length == 0)
                return null;
            else
                return res[0];
        }

        public void addSortedOutFile(String folderName, String fileName)
        {
            addItemToTreeView(folderName, fileName, treeViewSortedOut.Nodes);
        }
    }
}
