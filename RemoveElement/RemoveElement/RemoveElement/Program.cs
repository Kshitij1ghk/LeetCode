using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveElement
{
    internal class Program
    {
        public int RemoveElement(int[] nums,int val)
        {
            int k = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if(nums[i] != val)
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;
        }
        //O(n)
        //nums = [3, 2, 2, 3], val = 3

        //      i=0: nums[0]=3 == val → skip
        //      i = 1: nums[1]=2 != val → nums[0]=2, k=1
        //      i=2: nums[2]=2 != val → nums[1]=2, k=2
        //      i=3: nums[3]=3 == val → skip

        //       Result: [2, 2, _, _], return k=2 ✅

       // k is not just a counter — it's a write pointer. i reads every element, k only advances when something is worth keeping.
        static void Main(string[] args)
        {
            
        }
    }
}
