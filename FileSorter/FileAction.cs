namespace FileSorter
{
    public interface FileAction
    {
        public abstract void action(FileInfo file, String folderTo);
        public abstract void createSubDirectory(String name);
        public DirectoryInfo[] getDirectories();
    }

    public abstract class RealFileAction : FileAction
    {
        private DirectoryInfo dstInfo;

        public RealFileAction(DirectoryInfo dstInfo)
        {
            this.dstInfo = dstInfo;
        }
        public void createSubDirectory(string name)
        {
            dstInfo.CreateSubdirectory(name);
        }

        public DirectoryInfo[] getDirectories()
        {
            return dstInfo.GetDirectories();
        }

        protected String createUrl(FileInfo file, String folderTo)
        {
            if (folderTo.Length == 0)
                return dstInfo.FullName + "\\" + file.Name;
            else
                return dstInfo.FullName + "\\" + folderTo + "\\" + file.Name;
        }

        public abstract void action(FileInfo file, String folderTo);
    }

    public class CopyAction : RealFileAction
    {
        public CopyAction(DirectoryInfo dstInfo) : base(dstInfo) { }
        public override void action(FileInfo file, String folderTo)
        {
            file.CopyTo(createUrl(file, folderTo));
        }
    }

    public class MoveAction : RealFileAction
    {
        public MoveAction(DirectoryInfo dirInfoDst) : base(dirInfoDst) { }
        public override void action(FileInfo file, String folderTo)
        {
            file.MoveTo(createUrl(file, folderTo));
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
