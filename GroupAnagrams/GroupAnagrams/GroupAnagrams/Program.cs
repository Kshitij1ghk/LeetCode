using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAnagrams
{
    internal class Program
    {
        //brute force method 
        static List<List<string>> GroupAnagrams(string[] strs)
        {
            List<List<string>> result = new List<List<string>>();
            bool[] visited=new bool[strs.Length];

            for (int i = 0; i < strs.Length; i++)
            {
                if (visited[i]) continue;
                
                List<string> group = new List<string>(); 
                group.Add(strs[i]); //add current word to its own group

                for(int j=i+1;j< strs.Length; j++)
                {
                    if (!visited[j] && IsAnagram(strs[i], strs[j])){
                        group.Add(strs[j]);
                        visited[j] = true;
                    }
                }
                result.Add(group);
            }
            return result;
        }
        //O(n^2xm) group every pair thats why more timecomplexity
        //this is a brute force method
        ///bool[] visited = new bool[strs.Length] creates an array of false values:
        ///strs =   ["eat", "tea", "tan", "ate", "nat", "bat"]
        ///index =    0      1      2      3      4      5
        ///visited = [false, false, false, false, false, false]
        /// Why do we need it?
        ///Without it, "tea" could get added to multiple groups:
        ///i=0 "eat" → groups with "tea", "ate" ✅
        ///i=1 "tea" → groups with "eat", "ate" again! ❌ duplicate!

        ///How it works step by step:
        ///i=0, "eat" not visited
        ///→ create new group ["eat"]
        ///→ j=1, "tea" is anagram → add to group, visited[1]=true
        ///→ j=2, "tan" not anagram → skip
        ///→ j=3, "ate" is anagram → add to group, visited[3]=true
        ///→ result = [["eat","tea","ate"]]
        ///visited = [false, TRUE, false, TRUE, false, false]

        ///i=1, "tea" → visited[1]=true → SKIP! ✅
        ///i=2, "tan" not visited
        ///→ create new group ["tan"]
        ///→ j=3, "ate" visited → skip
        ///→ j=4, "nat" is anagram → add, visited[4]=true
        ///→ result = [["eat","tea","ate"], ["tan","nat"]]

        ///i=3, "ate" → visited → SKIP! ✅
        ///i=4, "nat" → visited → SKIP! ✅
        ///i=5, "bat" not visited
        ///→ create new group ["bat"]
        ///→ no more words
        ///→ result = [["eat","tea","ate"], ["tan","nat"], ["bat"]]

        ///In short — visited prevents a word from being added to multiple groups! 🎯
        static bool IsAnagram(string s,string t)
        {
            if(s.Length!=t.Length) return false;

            Dictionary<char,int> map=new Dictionary<char,int>();
            for(int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                    map[s[i]] = map[s[i]] + 1;
                else
                    map[s[i]] = 1;
            }
            for(int i = 0;i < t.Length; i++)
            {
                if (map.ContainsKey(t[i]))
                    map[t[i]] = map[t[i]] - 1;
                else
                    return false;
            }

            foreach(int count in map.Values)
            {
                if (count != 0)
                {
                    return false;
                }
                
            }
            return true;
        }
        /// 

        static List<List<string>> GroupAnagramsHashMap(string[] strs)
        {
            Dictionary<string,List<string>> map=new Dictionary<string,List<string>>();
            foreach(string word in strs)
            {
                char[] chars=word.ToCharArray();
                Array.Sort(chars);
                string key = new string(chars);
                if (!map.ContainsKey(key))
                {
                    map[key] = new List<string>();
                }
                map[key].Add(word);
            }
            return new List<List<string>>(map.Values)   ;
        }

        ///now here we used the hashmap approach 
        /// that is we first sort the string then we store it in hashmap
        /// and in front of it you add the words that mach the sorted one 
        /// thus creating list refer to https://www.coursera.org/learn/packt-introduction-to-fundamental-data-structures-and-techniques-9zdns/lecture/VHk7n/group-anagrams-49 if doubts
        /// has tc-O(n x klogk)
        

        static List<List<string>> GroupAnagramFrequency(String[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach(string word in strs)
            {
                int[] count = new int[26]; //reset for every word
                foreach(char c in word) //loop over characters in word
                {
                    count[c - 'a']++; //increment character frequency
                }

                string key=string.Join(",", count); //turns count into key

                if(!map.ContainsKey(key))
                    map[key]=new List<string>();
                map[key].Add(word);
            }

            return new List<List<string>>(map.Values);
        }
       /// Step 1 — Create the dictionary:
///csharpDictionary<string, List<string>> map = new Dictionary<string, List<string>>();
///```
///Creates empty storage:
///{
///    // nothing yet
///}

///Step 2 — Loop over each word:
///csharpforeach(string word in strs)
///```
///strs = ["eat", "tea", "bat"]
///first iteration  → word = "eat"
///second iteration → word = "tea"
///third iteration  → word = "bat"

///Step 3 — Reset count array every word:
///csharpint[] count = new int[26];
///```
///```
///"eat" → count = [0,0,0,0,0,0,...] fresh start!
///"tea" → count = [0,0,0,0,0,0,...] fresh start!
///"bat" → count = [0,0,0,0,0,0,...] fresh start!
///// if this was OUTSIDE the loop, counts would
///// carry over from previous word! ❌

///Step 4 — Count each character:
///csharpforeach(char c in word)
///    count[c - 'a']++;
///```
///```
///word = "eat"
///'e' → c-'a' = 4  → count[4]++  → count[4]=1
///'a' → c-'a' = 0  → count[0]++  → count[0]=1
///'t' → c-'a' = 19 → count[19]++ → count[19]=1
///
///count = [1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0]
///         a       e                             t

///Step 5 — Turn count into a string key:
///csharpstring key = string.Join(",", count);
///```
///```
///count = [1,0,0,0,1,0,...,1,...]
///key   = "1,0,0,0,1,0,...,1,..."

// "eat" and "tea" both produce same key!
// that's how we know they're anagrams!

///Step 6 — Create new list if key doesn't exist:
///csharpif(!map.ContainsKey(key))
///    map[key] = new List<string>();
///```
///```
///"eat" → key not in map → create new list
///map = { "1,0,0,0,1,...": [] }

///"tea" → key already exists → skip this step!
///map = { "1,0,0,0,1,...": [] } // unchanged

///Step 7 — Add word to its group:
///csharpmap[key].Add(word);
///```
///```
///"eat" → map = { "1,0,0,0,1,...": ["eat"] }
///"tea" → map = { "1,0,0,0,1,...": ["eat","tea"] }
///"bat" → map = { "1,0,0,0,1,...": ["eat","tea"],
///                "1,1,0,0,0,...": ["bat"] }

///Step 8 — Return all groups:
///csharpreturn new List<List<string>>(map.Values);
///```
///```
///map.Values = [["eat","tea"], ["bat"]]
///// just extract all the lists from dictionary!
///```

///---

///Full picture:
///```
///word  → count chars → build key → group by key
///"eat" → a1e1t1      → "1,0,0,0,1,...,1,..." → group 1
///"tea" → a1e1t1      → "1,0,0,0,1,...,1,..." → group 1 ✅ same!
///"bat" → a1b1t1      → "1,1,0,0,0,...,1,..." → group 2
///
        static void Main(string[] args)
        {
            string[] strs = { "eat", "tea", "tan", "ate", "nat", "bat" };

            List<List<string>> result = GroupAnagrams(strs);

            // print the groups
            foreach (List<string> group in result)
            {
                Console.WriteLine("[" + string.Join(", ", group) + "]");
            }

            List<List<string>> result1 = GroupAnagramsHashMap(strs);
            foreach(List<string> group in result1)
            {
                Console.WriteLine("[" + string.Join(", ", group) + "]");
            }
        }
        
    }
}
