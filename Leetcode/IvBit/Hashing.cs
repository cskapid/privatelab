using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.IvBit
{
    public class Hashing
    {
        public void ContestValidator()
        {
            #region FractionToDecimal
            var A = 22;
            var B = 7;
            var res = Timer.TimedFunc(() => this.FractionToDecimal(A, B));
            Console.WriteLine("{0} took {1} ticks.", "FractionToDecimal", res.TimeSpan.Ticks);
            #endregion //FractionToDecimal

            #region MinWindow
            //var A = "ADOBECODEBANC";
            //var B = "ABC";
            //var res = Timer.TimedFunc(() => this.MinWindow(A, B));
            //Console.WriteLine("{0} took {1} ticks.", "MinWindow", res.TimeSpan.Ticks);
            #endregion //MinWindow

            #region FindSubstring
            //var A = "barfoothefoobarman";
            //var B = new List<string> {
            //    "foo",
            //    //"the",
            //    "bar"
            //};
            //var res = Timer.TimedFunc(() => this.FindSubstring(A, B));
            //Console.WriteLine("{0} took {1} ticks.", "FindSubstring", res.TimeSpan.Ticks);
            #endregion //FindSubstring

            #region Equal
            //var A = new List<int> {
            //    3, 4, 7, 1, 2, 9, 8
            //};
            //var res = Timer.TimedFunc(() => this.Equal(A));
            //Console.WriteLine("{0} took {1} ticks.", "Equal", res.TimeSpan.Ticks);
            #endregion //Equal

            #region IsValidSudoku
            //var A = new List<string> {
            //    "53..7....",
            //    "6..195...",
            //    ".98....6.",
            //    "8...6...3",
            //    "4..8.3..1",
            //    "7...2...6",
            //    ".6....28.",
            //    "...419..5",
            //    "....8..79"
            //};
            //var res = Timer.TimedFunc(() => this.IsValidSudoku(A));
            //Console.WriteLine("{0} took {1} ticks.", "IsValidSudoku", res.TimeSpan.Ticks);
            #endregion //IsValidSudoku

        }

        #region FractionToDecimal
        public string FractionToDecimal(int A, int B)
        {
            var res = new StringBuilder();
            if ((A != 0) && ((A < 0 && B >= 0) || (A >= 0 && B < 0)))
            {
                res.Append("-");
            }
            long D = Math.Abs((long) B);
            long Q = Math.Abs((long)A / D);
            long R = Math.Abs((long) A % D);
            res.Append(Q);
            if (R != 0)
            {
                res.Append(".");
                List<long> set = new List<long>();
                while (R != 0)
                {
                    set.Add(R);
                    var tR = ((long) R * 10) % D;
                    if (tR == 0)
                    {
                        foreach (var item in set)
                        {
                            res.Append((long)item * 10 / D);
                        }
                        break;
                    }
                    else
                    {
                        var i = set.IndexOf(tR);
                        if (i >= 0)
                        {
                            int j = 0;
                            for (;j<i;j++)
                            {
                                res.Append((long)set[j] * 10 / D);
                            }
                            res.Append("(");
                            for(;j<set.Count;j++)
                            {
                                res.Append((long)set[j] * 10 / D);
                            }
                            res.Append(")");
                            break;
                        }
                    }
                    R = tR;
                } 
            }
            return res.ToString();
            /*
            long A = a;
            long B = b;
            bool sign = false;
            if (A < 0 && B > 0 || A > 0 && B < 0){
                sign = true;
            }
        
            A = A < 0? -A : A;
            B = B < 0? -B : B;
        
            long d = A/B;
            A %= B;
        
            if (A == 0) return d.ToString();
        
            List<char> chars = new List<char>();
            long f = 0, r = 0;
            var remainders = new Dictionary<long, int>();
            while (A > 0){
                A *= 10;
                f = A/B;
                //Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", A, B, r, f));
                //string key = string.Format("{0}|{1}", r, f);
                if(remainders.ContainsKey(A)){
                    chars.Insert(remainders[A], '(');
                    chars.Add(')');
                    break;
                }
            
                remainders[A] = chars.Count;
                A %= B;
                chars.Add((char)((int)f + '0'));
            }
        
            return (sign? "-" : "") + d.ToString() + "." + new string(chars.ToArray());        
            */
        }
        #endregion //FractionToDecimal

        #region MinWindow
        public string MinWindow(string A, string B)
        {
            int len1 = A.Length;
            int len2 = B.Length;

            int minLen = Int32.MaxValue;
            int finalStart = 0;
            int[] dp = new int[256];
            for (int i = 0; i < len2; i++)
            {
                dp[B[i]]++;
            }
            int start = 0;
            int end = 0;
            int count = len2;
            while (end < len1)
            {
                if (dp[A[end]] > 0)
                {
                    count--;
                }
                dp[A[end]]--;

                while (count == 0)
                {
                    if (end - start + 1 < minLen)
                    {
                        finalStart = start;
                        minLen = end - start + 1;
                    }
                    dp[A[start]]++;
                    if (dp[A[start]] > 0)
                    {
                        count++;
                    }
                    start++;
                }
                end++;
            }

            if (minLen == Int32.MaxValue)
            {
                return "";
            }
            return A.Substring(finalStart, minLen);            
            
            /*
            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B))
            {
                return string.Empty;
            }

            if (A.Length < B.Length)
            {
                return string.Empty;
            }

            if (string.CompareOrdinal(A, B) == 0)
            {
                return A;
            }

            int len = int.MaxValue;
            int index = -1;
            int i = 0;
            int maxLastIndex = A.Length - B.Length;
            int charsLeft = B.Length;
            var lastFoundIndex = -1;
            int[] charCount = new int[256];
            foreach(var c in B)
            {
                charCount[c]++;
            }
            while (i < maxLastIndex)
            {
                charCount[A[i]]--;
                lastFoundIndex = B.IndexOf(A[i]);
                if (lastFoundIndex == -1)
                {
                    i++;
                    continue;
                }
                if (charCount[A[i]] >= 0)
                {
                    charsLeft--;
                }
                int j = i + 1;
                for (;j< A.Length-charsLeft && charsLeft > 0;j++)
                {
                    charCount[A[j]]--;
                    if (B.IndexOf(A[j]) > -1 && charCount[A[j]] >= 0)
                    {
                        charsLeft--;
                    }
                }
                if (charsLeft == 0)
                {
                    if (j - i < len)
                    {
                        len = j - i;
                        index = i;
                    }
                    charsLeft = B.Length;
                    lastFoundIndex = -1;
                    foreach (var c in B)
                    {
                        charCount[c]++;
                    }
                }
                i++;
            }
            if (index == -1)
            {
                return string.Empty;
            }

            return A.Substring(index, len);
            */
        }
        #endregion //MinWindow

        #region FindSubstring
        public List<int> FindSubstring(string A, List<string> B)
        {
            if (B == null || B.Count == 0 || B[0].Length == 0)
            {
                return new List<int>();
            }

            var ret = new List<int>();
            int lLen = B[0].Length;
            for (int i = 0; i < lLen; i++)
            {
                int left = 0;
                int right = 0;
                var requiredCountMap = InitMap(B);
                int totalCount = B.Count;
                var index = i;
                var found = false;
                while (index + lLen <= A.Length)
                {
                    var subStr = A.Substring(index, lLen);
                    if (requiredCountMap.ContainsKey(subStr))
                    {
                        requiredCountMap[subStr] -= 1;
                        totalCount--;
                        left = index;
                        right = index;
                        found = true;
                        break;
                    }

                    index += lLen;
                }

                if (!found)
                {
                    continue;
                }

                while (left + lLen <= A.Length)
                {
                    if (totalCount == 0)
                    {
                        var subStr = A.Substring(left, lLen);
                        ret.Add(left);
                        requiredCountMap[subStr] += 1;
                        totalCount++;
                        left += lLen;
                    }
                    else
                    {
                        if (right < left)
                        {
                            right = left;
                        }
                        else
                        {
                            right += lLen;
                        }

                        if (right + lLen <= A.Length)
                        {
                            var newSubStr = A.Substring(right, lLen);
                            if (requiredCountMap.ContainsKey(newSubStr))
                            {
                                requiredCountMap[newSubStr] -= 1;
                                totalCount--;
                                if (requiredCountMap[newSubStr] < 0)
                                {
                                    while (left < right)
                                    {
                                        var subStr2 = A.Substring(left, lLen);
                                        requiredCountMap[subStr2] += 1;
                                        totalCount++;
                                        left += lLen;
                                        if (subStr2.Equals(newSubStr))
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                left = right + lLen;
                                requiredCountMap = InitMap(B);
                                totalCount = B.Count;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return ret;
        }

        private static Dictionary<string, int> InitMap(List<string> ls)
        {
            var map = new Dictionary<string, int>();
            foreach (var l in ls)
            {
                if (map.ContainsKey(l))
                {
                    map[l] += 1;
                }
                else
                {
                    map[l] = 1;
                }
            }

            return map;
        }
        #endregion //FindSubstring

        #region Equal
        public List<int> Equal(List<int> A)
        {
            List<int> ans = new List<int>();
            int isFound = 0;
            int n = A.Count;
            for (int i = 0; i <= n - 4 && isFound == 0; i++)
                for (int j = i + 1; j <= n - 3 && isFound == 0; j++)
                {
                    int sum = A[i] + A[j];
                    for (int k = i + 1; k <= n - 2 && isFound == 0; k++)
                        for (int l = k + 1; l <= n - 1 && isFound == 0; l++)
                        {
                            if (j == k || l == j)
                                continue;
                            if (A[k] + A[l] == sum)
                            {
                                ans.Add(i);
                                ans.Add(j);
                                ans.Add(k);
                                ans.Add(l);
                                isFound = 1;
                            }
                        }
                }
            return ans;
        }
        #endregion //Equal

        #region IsValidSudoku
        public int IsValidSudoku(List<string> A)
        {
            for (int i = 0; i < A.Count; i++)
            {
                int[] set = new int[9];
                for (int k = 0; k < set.Length; k++) set[k] = 0;
                for (int j = 0; j < A[i].Length; j++)
                {
                    if (A[i][j] == '.') continue;
                    if (set[A[i][j] - '1'] == 1) return 0;

                    set[A[i][j] - '1'] = 1;
                }
            }
            for (int colNum = 0; colNum < A.Count; colNum++)
            {
                int[] set = new int[9];
                for (int k = 0; k < set.Length; k++) set[k] = 0;
                for (int j = 0; j < A[colNum].Length; j++)
                {
                    if (A[j][colNum] == '.') continue;
                    if (set[A[j][colNum] - '1'] == 1) return 0;
                    set[A[j][colNum] - '1'] = 1;
                }
            }
            for (int cubeRow = 0; cubeRow < A.Count / 3; cubeRow++)
            {
                for (int cubeCol = 0; cubeCol < A.Count / 3; cubeCol++)
                {
                    int[] set = new int[9];
                    for (int k = 0; k < set.Length; k++) set[k] = 0;
                    for (int i = cubeRow * 3; i < (cubeRow + 1) * 3; i++)
                    {
                        for (int j = cubeCol * 3; j < (cubeCol + 1) * 3; j++)
                        {
                            if (A[i][j] == '.') continue;
                            if (set[A[i][j] - '1'] == 1) return 0;
                            set[A[i][j] - '1'] = 1;
                        }

                    }
                }

            }



            return 1;

        }
        #endregion //IsValidSudoku
    }
}
