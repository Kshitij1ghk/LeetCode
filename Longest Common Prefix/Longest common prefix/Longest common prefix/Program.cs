using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_common_prefix
{
    class Program
    {
        public string Longest_common_prefix(string[] strs)
        {
            string prefix = strs[0];

            for(int i = 1; i < strs.Length; i++)
            {
                while (!strs[i].StartsWith(prefix))
                {
                    prefix=prefix.Substring(0,prefix.Length-1);
                    if (prefix = "") return "";
                }
            }
            return prefix;
        }

        //Sure! Let's go line by line:

//csharpstring prefix = strs[0];
//You assume the first string is the answer to start with. It's the biggest possible prefix it could ever be. Example: prefix = "flower"

//csharpfor (int i = 1; i < strs.Length; i++)
//You start from index 1 (not 0) because index 0 is already your prefix. You're now going through every other string to check if your prefix works for them too.

//csharpwhile (!strs[i].StartsWith(prefix))
//You ask — does the current string begin with your prefix? If not, your prefix is too long and needs to be shrunk. Example: Does "flow" start with "flower"? No → enter the loop.

//csharpprefix = prefix.Substring(0, prefix.Length - 1);
//Substring(0, n) gives you the first n characters. So prefix.Length - 1 just chops off the last character one at a time. Example: "flower" → "flowe" → "flow" → until it matches.

//csharpif (prefix == "") return "";
//If you've shrunk the prefix down to nothing, there's no common prefix at all — return empty string immediately. No point continuing.
        static void Main(string[] args)
        {

        }
    }
}
