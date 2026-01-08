namespace FileSorter
{
    public enum FilterMode { CreationDate, LastChangedDate }
    public abstract class FileFilter
    {
        public abstract bool validate(FileInfo file);
    }

    public class NameStartFilter : FileFilter
    {
        public readonly String nameStart;
        public NameStartFilter(string nameStart) {
            this.nameStart = nameStart;
        }

        public override bool validate(FileInfo file)
        {
            return Path.GetFileNameWithoutExtension(file.Name).StartsWith(nameStart);
        }
    }

    public class NameContentsFilter : FileFilter
    {
        private String nameContent;
        public NameContentsFilter(string nameContent) {
            this.nameContent = nameContent;
        }

        public override bool validate(FileInfo file)
        {
            return Path.GetFileNameWithoutExtension(file.Name).Contains(nameContent);
        }
    }

    public class ExtensionFilter : FileFilter
    {
       public readonly String extension;
        public ExtensionFilter(string extension) {
            this.extension = extension;
        }

        public override bool validate(FileInfo file)
        {
            return file.Extension.Equals("." + extension);
        }
    }

    public class DateSpanFilter: FileFilter
    {
        public readonly DateTime? from;
        public readonly DateTime? until;
        public readonly FilterMode filterMode;

        public DateSpanFilter(DateTime? from, DateTime? until, FilterMode filterMode)
        {
            this.from = from;
            this.until = until;
            this.filterMode = filterMode;
        }

        public override bool validate(FileInfo file)
        {
            DateTime? lastDate;
            if(filterMode == FilterMode.CreationDate)
            {
                lastDate = file.CreationTime.Date;
            } else
            {
                lastDate = file.LastWriteTime.Date;
            }
            if ((from != null && lastDate <= from) || (until != null && until <= lastDate))
                return false;
            return true;
        }
    }
}
