using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusOne
{

    internal class Program
    {
        public int[] PlusOne(int[] digits)
        {
            
            int i = digits.Length-1;
            while (i >= 0)
            {
                if(digits[i] < 9)
                {
                    digits[i]=digits[i]+1;
                    return digits;
                }
                else if(digits[i] == 9)
                {
                    if (i == 0)
                    {
                        digits=new int[digits.Length+1];
                        for(int j=0; j<digits.Length; j++)
                        {
                            if (j == 0)
                            {
                                digits[j] = 1;
                            }
                            else
                            {
                                digits[j] = 0;
                            }
                        }
                        return digits;
                    }
                    digits[i] =0;
                    i--;
                    
                }
                
               
            }
            return digits;

        }
        static void Main(string[] args)
        {
        }
    }
}
