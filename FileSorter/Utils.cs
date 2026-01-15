using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (parent.Tag.GetType() != typeof(int))
                throw new ArgumentException("Tag is no int");
            return (int)parent.Tag;
        }
        public static bool parseVariables(String text, String pattern, out String[] res)
        {

            String[] parts = Regex.Split(pattern, "\\?");
            res = new String[parts.Length - 1];
            int res_count = 0;

            int text_pos = 0;
            int beginOfVariable = 0;
            if (parts[0].Length != 0) //if first is no variable, check it with this part, then starting to pass over the variable area to the next part
            {
                if (!substringMatch(text, parts[0], text_pos))
                    return false;
                beginOfVariable = text_pos = parts[0].Length;
            }

            for (int i = 1; i < parts.Length; i++)
            {
                //handle if pattern has variable at end
                if(i == parts.Length - 1 && parts[i].Length == 0)
                {
                    if (text_pos < text.Length - 1) {
                        res[res_count++] = text.Substring(text_pos, text.Length - text_pos);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                while (!substringMatch(text, parts[i], text_pos))
                {
                    //vorzeitig am Ende des Textes angekommen
                    if (text_pos + parts[i].Length > text.Length)
                        return false;
                    text_pos++;
                }
                int current_res_len = text_pos - beginOfVariable;
                res[res_count++] = text.Substring(beginOfVariable, current_res_len);
                text_pos += parts[i].Length;
                beginOfVariable = text_pos;
            }
            if (text_pos < text.Length) // if no variable at end but still chars after the last part
                return false;
            return true;
        }

        private static bool substringMatch(String s, String subString, int start)
        {
            if (s.Length - start < subString.Length)
                return false;
            for (int i = 0; i < subString.Length; i++)
            {
                if (s[start + i] != subString[i])
                    return false;
            }
            return true;
        }
    }
}
