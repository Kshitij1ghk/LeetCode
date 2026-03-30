using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman_to_integer
{
    internal class Program
    {
        public int RomanToInt(string s)
        {
            int sum = 0;
           
            Dictionary<char,int > Roman=new Dictionary<char,int>();
            Roman.Add('I', 1);
            Roman.Add('V', 5);
            Roman.Add('X', 10);
            Roman.Add('L', 50);
            Roman.Add('C', 100);
            Roman.Add('D', 500);
            Roman.Add('M', 1000);
            for(int i = 0; i < s.Length; i++)
            {

                if (i + 1 < s.Length)
                {
                    if (Roman[s[i + 1]] > Roman[s[i]])
                    {
                        sum += Roman[s[i + 1]] - Roman[s[i]];
                        i++;
                    }
                    else
                    {
                        sum += Roman[s[i]];
                    }
                }
                else
                {
                    sum += Roman[s[i]];
                }
                
            }
            return sum;
        }
        static void Main(string[] args)
        {
        }
    }
}
