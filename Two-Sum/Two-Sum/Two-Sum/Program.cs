using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Sum
{
    internal class Program
    {
        static void TwoSum(int[] nums,int target) //my=bruteforce approach not good since O(n^2)
        {
        
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        Console.WriteLine($"Two indices are {i} and {j}");
                        return;
                    }
                }
            }
        }
        ///solution -2
        //so when finding and solving such questions its might be better if we sort them first
        //so for the next logic or efficient solution the first thing we will do is sort array first
        ///then after sorting we know that the first element will be the smallest and last element will be the largest
        ///so we add first and last first and if their sum>19 we move one index less than last 
        ///and add again and now during that if its less we move one index more than first one so we get the sum
        ///for target easily O(nlogn)
        ///
        static void quickSort(int[] array,int low,int high)
        {
            if (low >= high)
            {
                return;
            }
            int pivotindex=Partition(array, low, high);
            quickSort(array, low, pivotindex - 1);
            quickSort(array, pivotindex + 1, high);
        }
        static int Partition(int[] array,int low,int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for(int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i = i + 1;
                    int temp1=array[i];
                    array[i] = array[j];
                    array[j] = temp1;
                }
            }
            int temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;
            return i + 1;
        }

        static void TwoSumS2(int[] array,int target)
        {
            quickSort(array,0,array.Length-1);
            int i = 0;
            int j = array.Length - 1;
            
            
            
            while(i < j)
            {
                int sum = array[i] + array[j];
                if (sum == target)
                {
                    Console.WriteLine($"two indices are {i} and {j}");
                    return;
                }
                if (sum > target)
                {
                    j--;
                    
                }
                else
                {
                    i++;
                }
            }

        }

        static void TwoSumHashMap(int[] array,int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for(int i = 0; i < array.Length; i++)
            {
                int compliment = target - array[i];
                if( map.ContainsKey(compliment))
                {
                    Console.WriteLine($"the indices are {i} and {map[compliment]}");
                }
                else
                {
                    map.Add(array[i],i);
                }
            }
        }
        //the above method is for quicksort for sortiung the elements
        static void Main(string[] args)
        {
            int[] nums = { 2, 7, 11, 15 };
            TwoSum(nums, 9); //O(n^2)

            TwoSumS2(nums, 9);//O(nlogn)

            TwoSumHashMap(nums, 9);

           

        }
    }
}
