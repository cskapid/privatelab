using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class Contest50
    {
        public void ContestValidator()
        {
            #region JudgePoint24
            var nums = new int[] {
                4, 1, 8, 7
                //1, 2, 1, 2
            };
            var res = Timer.TimedFunc(() => this.JudgePoint24(nums));
            Console.WriteLine("{0} took {1} ticks.", "JudgePoint24", res.TimeSpan.Ticks);
            #endregion //JudgePoint24

            #region CheckValidString
            //var list = new List<string> {
            //    "(())((())()()(*)(*()(())())())()()((()())((()))(*", //false
            //    "()()()", // true
            //    "((()))", // true
            //    "((*))", // true
            //    "(*()()", // true
            //    "((*)()", // true
            //    "(*))()", // true
            //    "()*)()", // true
            //    "((*))((()))", // true
            //    "(()()(*)(*)))",
            //    "()()(*()()", // true
            //    "((*))(()))" // true
            //};
            //foreach (var s in list)
            //{
            //    var res = Timer.TimedFunc(() => this.CheckValidString(s));
            //    //Console.WriteLine("{0} took {1} ticks.", "ValidPalindrome", res.TimeSpan.Ticks);
            //    Console.WriteLine("Input: {0} --> Output:{1}", s, res.Result);
            //}
            #endregion CheckValidString

            #region ValidPalindrome
            //var list = new List<string> {
            //    "abcdebdcba",
            //    "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga",
            //    "deeee",
            //    "aba",
            //    "abba",
            //    "abbca",
            //    "acbba",
            //    "abc",
            //    "abbc",
            //    "deede"
            //};
            //foreach (var s in list)
            //{
            //    var res = Timer.TimedFunc(() => this.ValidPalindrome(s));
            //    //Console.WriteLine("{0} took {1} ticks.", "ValidPalindrome", res.TimeSpan.Ticks);
            //    Console.WriteLine("Input: {0} --> Output:{1}", s, res.Result);
            //}
            #endregion //ValidPalindrome
        }

        #region JudgePoint24
        public bool JudgePoint24(int[] nums)
        {

        }
        #endregion //JudgePoint24

        #region CheckValidString
        public bool CheckValidString(string s)
        {
            Stack<int> lpStack = new Stack<int>();
            Stack<int> starStack = new Stack<int>();
            for(int i=0;i<s.Length;i++)
            {
                if (s[i] == '(')
                {
                    lpStack.Push(i);
                    continue;
                }
                if (s[i] == '*')
                {
                    starStack.Push(i);
                    continue;
                }
                if (lpStack.Count == 0 && starStack.Count == 0)
                {
                    return false;
                }
                if (lpStack.Count != 0)
                {
                    lpStack.Pop();
                    continue;
                }
                starStack.Pop();
            }
            while(lpStack.Count > 0 && starStack.Count > 0)
            {
                if (lpStack.Pop() > starStack.Pop())
                {
                    return false;
                }
            }
            return lpStack.Count == 0;
            // Old code
            //int wildcards = 0;
            //for(int i=0;i<s.Length;i++)
            //{
            //    if (s[i] == '(' || s[i] == '*')
            //    {
            //        stack.Push(s[i]);
            //        continue;
            //    }
            //    if (s[i] == ')')
            //    {
            //        if (stack.Count > 0)
            //        {
            //            stack.Pop();
            //            continue;
            //        }
            //        else if (wildcards > 0)
            //        {
            //            wildcards--;
            //            continue;
            //        }
            //        return false;
            //    }
            //}
            //if (stack.Count > wildcards)
            //{
            //    return false;
            //}
            //return true;
        }

        private bool IsValidString(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach(var c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                    continue;
                }
                if (stack.Count == 0 || stack.Pop() != '(')
                {
                    return false;
                }
            }
            if (stack.Count != 0)
            {
                return false;
            }
            return true;
        }
        #endregion //CheckValidString

        #region ValidPalindrome
        public bool ValidPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            int i = 0;
            int j = s.Length-1;
            while(i < j)
            {
                if (s[i] == s[j])
                {
                    i++;
                    j--;
                    continue;
                }
                if (!IsPalindrome(s.Substring(i + 1, j-i)) && !IsPalindrome(s.Substring(i, j-i)))
                {
                    return false;
                }

                break;
            }
            return true;
        }

        private bool IsPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                if (s[i] != s[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
        #endregion //ValidPalindrome
        
        #region MapSum
        private class MapSum
        {
            SortedDictionary<string, int> map = new SortedDictionary<string, int>();

            public MapSum()
            {

            }

            public void Insert(string key, int val)
            {
                if (map.ContainsKey(key))
                {
                    map[key] = val;
                }
                else
                {
                    map.Add(key, val);
                }
            }

            public int Sum(string prefix)
            {
                return map.Where((x) => { return x.Key.StartsWith(prefix); }).Sum((x) => x.Value);
            }
        }
        #endregion //ValidPalindrome
    }
}
