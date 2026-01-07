using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorter
{
    public abstract class FileFilter
    {
        protected String argument;
        public FileFilter(String argument)
        {
            this.argument = argument;
        }
        public abstract bool validate(FileInfo file);
    }

    public class NameStartFilter : FileFilter
    {
        public NameStartFilter(string argument) : base(argument) { }

        public override bool validate(FileInfo file)
        {
            return Path.GetFileNameWithoutExtension(file.Name).StartsWith(argument);
        }
    }

    public class NameContentsFilter : FileFilter
    {
        public NameContentsFilter(string argument) : base(argument) { }

        public override bool validate(FileInfo file)
        {
            return Path.GetFileNameWithoutExtension(file.Name).Contains(argument);
        }
    }

    public class ExtensionFilter : FileFilter
    {
        public ExtensionFilter(string argument) : base(argument) { }

        public override bool validate(FileInfo file)
        {
            return file.Extension.Equals("." + argument);
        }
    }
}
