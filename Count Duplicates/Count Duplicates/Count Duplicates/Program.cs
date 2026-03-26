using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Count_Duplicates
{
    internal class Program
    {
        static bool CountDuplicates(int[] array)
        {
            
            for(int i=0; i<array.Length; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        } //this is solution 1 that is brute force approach with O(n^2) time complexity so not good

        //next solution we will go with out usual that is sort first 
        static int Partition(int[] array,int low ,int high)
        {
            int pivot = array[high];
            int i = low - 1;
            for(int j = low; j < high; j++)
            {
                if (array[j]<= pivot)
                {
                    i = i + 1;
                    int temp1 = array[i];
                    array[i] = array[j];
                    array[j] = temp1;
                }
            }
            int temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;
            return i + 1;
        }
       static void QuickSort(int[] array,int low,int high)
        {
            if (low >= high)
            {
                return;
            }
            int pivotindex=Partition(array, low, high);
            QuickSort(array, low, pivotindex - 1);
            QuickSort(array,pivotindex+1, high);
        }

        static bool CountDuplicateSort(int[] array)
        {
            //this uses sorting method
            QuickSort(array, 0, array.Length-1);
            for(int i=0; i<array.Length-1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    return true;
                }
            }
            return false;

        }
        static bool CountDuplicatesHash(int[] array)
        {
            Dictionary<int, int> HashMap = new Dictionary<int, int>();
            for(int i = 0; i < array.Length; i++)
            {
                if (HashMap.ContainsKey(array[i]))
                {
                    return true;
                }
                else
                {
                    HashMap[array[i]] = i;
                }
            }
            return false;
        }//using dictionary
        //nums = [8, 3, 5]

        //i = 0 → HashMap[8] = 0  →  map = { 8:0 }
        //i=1 → HashMap[3] = 1  →  map = { 8:0, 3:1 }
        //i=2 → HashMap[5] = 2  →  map = { 8:0, 3:1, 5:2 } this is how the the adding into dictionary works here

        static bool CountDuplicatesHashSet(int[] array)
        {
            HashSet<int> set = new HashSet<int>();
            for(int i=0;i < array.Length; i++)
            {
                if (!set.Add(array[i]))
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            int[] array = {1, 2, 3, 1};
            int[] array2 = { 5, 6, 7, 8, 9 };

            Console.WriteLine(CountDuplicates(array)); //TC-O(n^2) sc-O(1)
            Console.WriteLine(CountDuplicateSort(array2));//TC-O(nlogn) sc-O(1) tc cuz sorting dominates
        }
    }
}
