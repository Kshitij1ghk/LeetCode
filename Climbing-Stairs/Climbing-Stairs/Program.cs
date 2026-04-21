using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climbing_Stairs
{
    internal class Program
    {
        public int ClimbStairs(int n)
        {
            int num1 = 0;
            int num2 = 1;
            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                
                sum = num1 + num2;
                num1 = num2;
                num2 = sum;
            }
            return sum;
        }
        static void Main(string[] args)
        {
        }
    }
}
