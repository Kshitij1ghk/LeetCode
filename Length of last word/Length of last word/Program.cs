using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Length_of_last_word
{
    internal class Program
    {
        public int LengthOfLastWord(string s)
        {
            int length = 0;
            int i = s.Length-1;
            while(i>=0 && s[i] == ' ')   i--;
            while(i>=0 && s[i] !=' ')
            {
                length++;
                i--;
            }
            return length;
        }
        static void Main(string[] args)
        {
        }
    }
}
