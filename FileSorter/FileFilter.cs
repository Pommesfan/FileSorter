using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorter
{
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

        public DateSpanFilter(DateTime? from, DateTime? until)
        {
            this.from = from;
            this.until = until;
        }

        public override bool validate(FileInfo file)
        {
            DateTime? lastDate = file.CreationTime.Date;
            if ((from != null && lastDate <= from) || (until != null && until <= lastDate))
                return false;
            return true;
        }
    }
}
