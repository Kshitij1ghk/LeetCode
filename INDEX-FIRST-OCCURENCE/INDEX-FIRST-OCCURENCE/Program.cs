using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDEX_FIRST_OCCURENCE
{
    internal class Program
    {
        public int StrStr(string haystack, string needle)
        {
            int length=haystack.Length-needle.Length;
            
            for(int i=0; i<=length; i++)
            {
                bool matched = true;
                for (int j = 0; j < needle.Length; j++)
                {
                    if (haystack[i+j] != needle[j])
                    {
                        matched = false;
                        break;
                    }              
                }
                if (matched) return i;
            }
            return -1;
           
        }
        static void Main(string[] args)
        {
        }
    }
}
