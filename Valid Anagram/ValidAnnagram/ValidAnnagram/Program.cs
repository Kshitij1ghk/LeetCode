using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidAnnagram
{
    internal class Program
    {
        static bool IsAnagram(string s,string t)
        {
            if(s.Length!=t.Length) return false;
            char[] sArr=s.ToCharArray();
            Array.Sort(sArr);
            string sSorted=new string(sArr);
            char[] tArr=t.ToCharArray();
            Array.Sort (tArr);
            string tSorted=new string(tArr);
            if (sSorted == tSorted)
            {
                return true;
            }
            return false;
        } //this is brute force approach we first sortefd the string and then compared them 

        static bool IsAnagramHash(string s, string t)
        {
            // Quick exit: different lengths can't be anagrams
            if (s.Length != t.Length) return false;

            Dictionary<char, int> map = new Dictionary<char, int>();

            // Step 1: Build character frequency map from s
            // s = "anagram" → { a:3, n:1, g:1, r:1, m:1 }
            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                    map[s[i]] = map[s[i]] + 1; // character seen before, increment
                else
                    map[s[i]] = 1;              // first time seeing this character
            }

            // Step 2: Decrease counts using t
            // t = "nagaram" → { a:0, n:0, g:0, r:0, m:0 }
            for (int i = 0; i < t.Length; i++)
            {
                if (map.ContainsKey(t[i]))
                    map[t[i]] = map[t[i]] - 1; // decrease count
                else
                    return false;               // character in t not found in s → not anagram
            }

            // Step 3: If all counts are 0 → anagram!
            // any count != 0 means mismatch
            foreach (int count in map.Values)
            {
                if (count != 0) return false;
            }

            return true; // all counts balanced → valid anagram ✅
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(IsAnagramHash("hello", "loleh"));
        }
    }
}
