namespace FileSorter
{
    public enum FilterMode { CreationDate, LastChangedDate, Extension, StartsWith, Contains }
    public abstract class FileFilter
    {
        public abstract bool validate(FileInfo file);
    }

    public abstract class FileNameFilter: FileFilter
    {
        public readonly String[] possibleKeyWords;
        public FileNameFilter(string[] possibleKeyWords)
        {
            this.possibleKeyWords = possibleKeyWords;
        }
    }

    public class NameStartFilter : FileNameFilter
    {
        public NameStartFilter(string[] possibleNameStarts) : base(possibleNameStarts) { }

        public override bool validate(FileInfo file)
        {
            String fileName = Path.GetFileNameWithoutExtension(file.Name);
            foreach (String item in possibleKeyWords)
            {
                if (fileName.StartsWith(item))
                    return true;
            }
            return false;
        }
    }

    public class NameContentsFilter : FileNameFilter
    {
        public NameContentsFilter(string[] possibleNameContents) : base(possibleNameContents) {}

        public override bool validate(FileInfo file)
        {
            String fileName = Path.GetFileNameWithoutExtension(file.Name);
            foreach (String item in possibleKeyWords)
            {
                if (fileName.Contains(item))
                    return true;
            }
            return false;
        }
    }

    public class ExtensionFilter : FileNameFilter
    {
        public ExtensionFilter(string[]extensions) : base(extensions) {}

        public override bool validate(FileInfo file)
        {
            String fileExtension = file.Extension;
            foreach(String s in possibleKeyWords)
            {
                if(fileExtension.Equals("." + s))
                    return true;
            }
            return false;
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
