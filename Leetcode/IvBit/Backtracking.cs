using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode.IvBit
{
    public class Backtracking
    {
        public void ContestValidator()
        {
            #region PalindromePartition
            var A = "aab";
            var res = Timer.TimedFunc(() => this.PalindromePartition(A));
            Console.WriteLine("{0} took {1} ticks.", "PalindromePartition", res.TimeSpan.Ticks);
            res.Result.ForEach((x) =>
            {
                Console.Write("[");
                if (x.Count > 0)
                {
                    var sb = new StringBuilder();
                    x.ForEach(y => sb.AppendFormat("{0} ", y));
                    Console.Write(sb.ToString(0, sb.Length - 1));
                }
                Console.WriteLine("]");
            });
            #endregion //PalindromePartition

            #region LetterCombinations
            //var A = new List<int> {
            //    2, 4, 5, 7//, 10, 15
            //};
            //var res = Timer.TimedFunc(() => this.Subsets(A));
            //Console.WriteLine("{0} took {1} ticks.", "Subsets", res.TimeSpan.Ticks);
            //res.Result.ForEach((x) => {
            //    Console.Write("[");
            //    if (x.Count > 0)
            //    {
            //        var sb = new StringBuilder();
            //        x.ForEach(y => sb.AppendFormat("{0} ", y));
            //        Console.Write(sb.ToString(0, sb.Length - 1));
            //    }
            //    Console.WriteLine("]"); 
            //});
            #endregion //LetterCombinations

            #region LetterCombinations
            //var A = "3456";
            //var res = Timer.TimedFunc(() => this.LetterCombinations(A));
            //Console.WriteLine("{0} took {1} ticks.", "LetterCombinations", res.TimeSpan.Ticks);
            //res.Result.ForEach(Console.WriteLine);
            #endregion //LetterCombinations

            #region PowMod
            //var A = 9;
            //var B = 3;
            //var C = 5;
            //var res = Timer.TimedFunc(() => this.PowMod(A, B, C));
            //Console.WriteLine("{0} took {1} ticks.", "PowMod", res.TimeSpan.Ticks);
            #endregion //PowMod

            #region ReverseList
            //var A = ListBuilder.BuildList(
            //    Enumerable.Range(1, 100000).ToArray()
            //    //new int[] {1, 2}
            //    );
            //var res = Timer.TimedFunc(() => this.ReverseList(A));
            //Console.WriteLine("{0} took {1} ticks.", "ReverseList", res.TimeSpan.Ticks);
            //res = Timer.TimedFunc(() => this.ReverseListRecurse(A));
            //Console.WriteLine("{0} took {1} ticks.", "ReverseListRecurse", res.TimeSpan.Ticks);
            #endregion //ReverseList
        }


        #region PalindromePartition
        public List<List<string>> PalindromePartition(string a)
        {
            if (string.IsNullOrEmpty(a))
                return new List<List<String>>();



            var ans = new List<List<String>>();

            for (int length = 1; length <= a.Length; length++)
            {
                List<String> row = new List<String>();
                String st = a.Substring(0, length);

                if (isPalindrome(st))
                {
                    row.Add(st);
                    if (length == a.Length)
                    {
                        ans.Add(row);
                    }
                    else
                    {
                        ans = findPartition(ans, row, a.Substring(length));
                    }
                }
            }

            return ans;
        }

        private List<List<String>> findPartition(List<List<String>> ans, List<String> row, String a)
        {
            for (int length = 1; length <= a.Length; length++)
            {
                List<String> curRow = new List<String>();

                for (int i = 0; i < row.Count; i++)
                {
                    curRow.Add(row[i]);
                }

                String st = a.Substring(0, length);

                if (isPalindrome(st))
                {
                    curRow.Add(st);
                    if (length == a.Length)
                    {
                        ans.Add(curRow);
                    }
                    else
                    {
                        ans = findPartition(ans, curRow, a.Substring(length));
                    }
                }
            }

            return ans;
        }

        private bool isPalindrome(String st)
        {
            for (int i = 0; i < st.Length / 2; i++)
            {
                if (st[i] != st[st.Length - 1 - i])
                    return false;
            }

            return true;
        }
        #endregion //PalindromePartition
        #region Subsets

        public List<List<int>> Subsets(List<int> A)
        {
            var res = new List<List<int>>();
            res.Add(new List<int>());

            if (A == null || A.Count == 0)
            {
                return res;
            }

            A.Sort();
            var n = A.Count;
            List<List<int>>[] subsetMem = new List<List<int>>[n];
            for (int i=n-1;i>=0;i--)
            {
                if (subsetMem[i] == null)
                {
                    subsetMem[i] = new List<List<int>>();
                }
                var sublist = new List<int>();
                sublist.Add(A[i]);
                subsetMem[i].Add(sublist);
                for (int j = i+1;j<n;j++)
                {
                    foreach(var item in subsetMem[j])
                    {
                        sublist = new List<int>();
                        sublist.Add(A[i]);
                        item.ForEach(x => sublist.Add(x));
                        subsetMem[i].Add(sublist);
                    }
                }
            }
            for(int i=0;i<n;i++)
            {
                foreach(var item in subsetMem[i])
                {
                    res.Add(item);
                }
            }

            return res;
        }

        #endregion //Subsets

        #region ReverseList
        public ListNode ReverseList(ListNode A)
        {
            Stack<ListNode> stack = new Stack<ListNode>();
            var temp = A;
            while (temp != null)
            {
                stack.Push(temp);
                temp = temp.next;
            }
            ListNode root = new ListNode(0);
            temp = root;
            while (stack.Count > 0)
            {
                temp.next = stack.Pop();
                temp = temp.next;
            }
            temp.next = null;
            return root.next;
        }
        public ListNode ReverseListRecurse(ListNode head)
        {
            return Reverse(head, null);
        }
        public static ListNode Reverse(ListNode head, ListNode prev)
        {
            if (head == null)
                return null;
            if (head.next == null)
            {
                head.next = prev;
                return head;
            }
            var newHead = Reverse(head.next, head);
            head.next = prev;
            return newHead;
        }
        #endregion //ReverseList

        #region PowMod
        public int PowMod(int A, int B, int C)
        {
            if (A == 0) return 0;
            if (B == 0) return 1;
            if (B == 1) return ((A % C) + C) % C;

            long a = ((long)(A % C) + C) % C;
            long c = (long)C;

            long half = (long)PowMod((int)a, B / 2, C);
            long result = (half * half) % c;

            if (B % 2 != 0)
            {
                result = (result * a) % c;
            }

            return (int)result;
        }
        #endregion //PowMod

        #region LetterCombinations
        private Dictionary<int, List<string>> letterComboMem = new Dictionary<int, List<string>>();
        public List<string> LetterCombinations(string A)
        {
            if (string.IsNullOrEmpty(A.Trim()))
            {
                return new List<string> { string.Empty };
            }

            int zero = 48;
            int cur = (int)A[0] - zero;
            if (letterComboMem.ContainsKey(cur))
            {
                return letterComboMem[cur];
            }
            var res = new List<string>();
            var dictionary = new string[] { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            if (cur < 0 || cur > 9)
            {
                throw new Exception("Invalid character in the string");
            }
            var letters = dictionary[cur];
            for(int j=0;j<letters.Length;j++)
            {
                var options = LetterCombinations(A.Substring(1));
                foreach(var item in options)
                {
                    res.Add(string.Format("{0}{1}", letters[j], item));
                }
            }
            letterComboMem[cur] = res;
            return res;
        }
        #endregion //LetterCombinations
    }
}
