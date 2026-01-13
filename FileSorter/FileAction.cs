namespace FileSorter
{
    public interface FileAction
    {
        public void action(FileInfo file, String folderTo);
        public void createSubDirectory(String name);
        public DirectoryInfo[] getDirectories();
    }

    public class CopyAction : FileAction
    {
        public readonly String dst;
        private DirectoryInfo dstInfo;
        public CopyAction(String dst)
        {
            this.dst = dst;
            this.dstInfo = new DirectoryInfo(dst);
        }
        public void action(FileInfo file, String folderTo)
        {
            String url;
            if (folderTo.Length == 0)
                url = dst + "\\" + file.Name;
            else
                url = dst + "\\" + folderTo + "\\" + file.Name;
            file.CopyTo(url);
        }

        public void createSubDirectory(string name)
        {
            dstInfo.CreateSubdirectory(name);
        }

        public DirectoryInfo[] getDirectories()
        {
            return dstInfo.GetDirectories();
        }
    }

    public class MoveAction : FileAction
    {
        public readonly String dst;
        private DirectoryInfo dstInfo;
        public MoveAction(String dst) {
            this.dst = dst;
            this.dstInfo = new DirectoryInfo(dst);
        }
        public void action(FileInfo file, String folderTo)
        {
            String url;
            if (folderTo.Length == 0)
                url = dst + "\\" + file.Name;
            else
                url = dst + "\\" + folderTo + "\\" + file.Name;
            file.MoveTo(url);
        }

        public void createSubDirectory(string name)
        {
            dstInfo.CreateSubdirectory(name);
        }

        public DirectoryInfo[] getDirectories()
        {
            return dstInfo.GetDirectories();
        }
    }
    public class PreviewAction : FileAction
    {
        private SortPreview sortPreview;
        private SortPreview dialog;

        public PreviewAction(SortPreview sortPreview, SortPreview dialog)
        {
            this.sortPreview = sortPreview;
            this.dialog = dialog;
        }

        public void action(FileInfo file, String folderTo)
        {
            sortPreview.addItem(folderTo, file.Name);
        }

        public void createSubDirectory(string name)
        {
            dialog.addFolder(name);
        }

        public DirectoryInfo[] getDirectories()
        {
            return new DirectoryInfo[] { };
        }
    }
}
