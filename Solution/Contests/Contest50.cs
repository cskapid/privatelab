using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution.Contests
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
            Array.Sort(nums);
            do
            {
                if (valid(nums))
                {
                    return true;
                }
            } while(NextPermutation(nums));

            return false;
        }

        private bool valid(int[] nums)
        {
            double a = nums[0];
            double b = nums[1];
            double c = nums[2];
            double d = nums[3];

            if (valid(a+b, c, d) ||
                valid(a-b, c, d) ||
                valid(a*b, c, d) ||
                (b != 0 && valid(a/b, c, d)))
            {
                return true;
            }
            if (valid(a, b+c, d) ||
                valid(a, b-c, d) ||
                valid(a, b*c, d) ||
                (c != 0 && valid(a, b/c, d)))
            {
                return true;
            }
            if (valid(a, b, c+d) ||
                valid(a, b, c-d) ||
                valid(a, b, c*d) ||
                (d != 0 && valid(a, b, c/d)))
            {
                return true;
            }

            return false;
        }

        private bool valid(double a, double b, double c)
        {
            if (valid(a+b, c) ||
                valid(a-b, c) ||
                valid(a*b, c) ||
                (b != 0 && valid (a/b, c)))
            {
                return true;
            }

            if (valid(a, b+c) ||
                valid(a, b-c) ||
                valid(a, b*c) ||
                (c != 0 && valid(a, b / c)))
            {
                return true;
            }

            return false;
        }

        private bool valid(double a, double b)
        {
            if (Math.Abs(a + b - 24.0) < 0.001 ||
                Math.Abs(a - b - 24.0) < 0.001 ||
                Math.Abs(a * b - 24.0) < 0.001 ||
                (b != 0 && (Math.Abs(a / b - 24.0) < 0.001)))
            {
                return true;
            }
            return false;
        }

        private bool NextPermutation<T>(T[] a) where T : IComparable
        { 
            if (a.Length < 2) return false;
            var k = a.Length - 2;

            while (k >= 0 && a[k].CompareTo(a[k + 1]) >= 0) k--;
            if (k < 0) return false;

            var l = a.Length - 1;
            while (l > k && a[l].CompareTo(a[k]) <= 0) l--;

            var tmp = a[k];
            a[k] = a[l];
            a[l] = tmp;

            var i = k + 1;
            var j = a.Length - 1;
            while (i < j)
            {
                tmp = a[i];
                a[i] = a[j];
                a[j] = tmp;
                i++;
                j--;
            }

            return true;
        }
        /*
        bool flag = false;

        public bool JudgePoint24(int[] nums)
        {
            var arr = new List<double>();
            foreach(var n in nums)
            {
                arr.Add((double)n);
            }
            helper(arr);
            return flag;
        }

        private void helper(List<double> arr)
        {
            const double eps = 0.001;

            if (flag)
            {
                return;
            }

            if (arr.Count == 1)
            {
                if (Math.Abs(arr[0] - 24.0) < eps)
                {
                    flag = true;
                    return;
                }
            }

            for(int i=0;i<arr.Count;i++)
            {
                for(int j=0;j<i;j++)
                {
                    var next = new List<double>();
                    var p1 = arr[i];
                    var p2 = arr[j];
                    next.AddRange(new double[] { p1 + p2, p1 - p2, p2 - p1, p1 * p2 });
                    if (Math.Abs(p2) > eps)
                    {
                        next.Add(p1 / p2);
                    }
                    if (Math.Abs(p1) > eps)
                    {
                        next.Add(p2 / p1);
                    }
                    arr.Remove(i);
                    arr.Remove(j);
                    foreach(var n in next)
                    {
                        arr.Add(n);
                        helper(arr);
                        arr.Remove(arr.Count - 1);
                    }
                    arr.Insert(j, p2);
                    arr.Insert(i, p1);
                }
            }
        }
        */
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
