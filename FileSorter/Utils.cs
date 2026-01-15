using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorter
{
    public class Utils
    {
        public static int getTagNumber(Control control)
        {
            if (control.Parent == null)
            {
                throw new ArgumentException("Parent to get Tagfrom is null");
            }
            Control parent = control.Parent;
            if (parent.Tag == null)
                throw new ArgumentException("Tag is null");
            if (parent.Tag.GetType() != typeof(Int32))
                throw new ArgumentException("Tag is no int");
            return (int)parent.Tag;
        }
    }
}
