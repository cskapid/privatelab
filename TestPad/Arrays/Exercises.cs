using System;
using System.Collections.Generic;
using System.Linq;

namespace TestPad.Arrays
{
    public class Exercises
    {
        public int FindLHS(int[] nums)
        {
            int length = 0;
            if (nums == null || nums.Length <= 1)
            {
                return length;
            }

            Array.Sort(nums);
            int prevLength = length;
            int curLength = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                var diff = nums[i] - nums[i-1];
                if (diff > 0)
                {
                    if (prevLength > 0)
                    {
                        length = System.Math.Max(length, (prevLength + curLength));
                    }
                    if (diff > 1)
                    {
                        prevLength = 0;
                        curLength = 1;
                    }
                    else
                    {
                        prevLength = curLength;
                        curLength = 1;
                    }
                    continue;
                }
                if (diff == 0)
                {
                    curLength++;
                }
            }
            if (prevLength > 0)
            {
                length = System.Math.Max(length, (prevLength + curLength));
            }

            /*
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach(var i in nums)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i] = dict[i] + 1;
                }
                else
                {
                    dict[i] = 1;
                }
            }

            var lastItem = dict.ElementAtOrDefault(0);
            for(var i=1; i<dict.Count; i++)
            {
                var item = dict.ElementAtOrDefault(i);
                var diff = item.Key - lastItem.Key;
                if (diff == 1)
                {
                    length = System.Math.Max(length, (lastItem.Value + item.Value));
                }

                lastItem = item;
            }
            */

            return length;
        }

        public int DistributeCandies(int[] candies)
        {
            if (candies == null || candies.Length == 0)
            {
                return 0;
            }

            var distinctCandies = candies.Distinct();
            return System.Math.Min(candies.Length / 2, distinctCandies.Count());
        }

        public int SubarraySum(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var tot = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var sum = nums[i];
                if (sum == k)
                {
                    tot++;
                }

                for (int j = i + 1; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum == k)
                    {
                        tot++;
                    }
                }
            }
            return tot;
        }

        public int MaximalLengthOfIncrementalSubsequence(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var length = new int[nums.Length];
            length[0] = 1;
            var max = length[0];
            for(var i=1;i<nums.Length; i++)
            {
                length[i] = 1;
                for(var j=0;j<i;j++)
                {
                    if (nums[i] > nums[j])
                    {
                        length[i] = System.Math.Max(length[i], length[j] + 1);
                    }
                }
                max = System.Math.Max(max, length[i]);
            }

            return max;
        }

        public int SingleNonDuplicate(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            return FindUniqueNumber(nums, 0, nums.Length - 1);
        }

        public int FindUniqueNumber(int[] nums, int start, int end)
        {
            if (start < 0 || end >= nums.Length)
            {
                return -1;
            }

            var midIndex = start + (end - start) / 2;
            var middle = nums[midIndex];
            var right = (midIndex + 1) < nums.Length ? nums[midIndex + 1] : -1;
            var left = (midIndex - 1) >= 0 ? nums[midIndex - 1] : -1;
            if (((midIndex == nums.Length - 1) || right != -1) && right != middle && (midIndex == 0 || left != -1) && left != middle)
            {
                return middle;
            }
            if (left == -1 || right == -1 || start == end)
            {
                return -1;
            }

            var leftUniqueNumber = FindUniqueNumber(nums, start, midIndex);
            if (leftUniqueNumber != -1)
            {
                return leftUniqueNumber;
            }
            var rightUniqueNumber = FindUniqueNumber(nums, midIndex + 1, end);
            if (rightUniqueNumber != -1)
            {
                return rightUniqueNumber;
            }

            return -1;
        }

        public int MajorityElement(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                throw new Exception("Null or empty array");
            }

            var candidate = FindCandidate(nums);
            var instances = 0;
            for (var i = 0; i < nums.Length && instances <= nums.Length / 2; i++)
            {
                if (nums[i] == candidate)
                {
                    instances++;
                }
            }
            if (instances > nums.Length / 2)
            {
                return candidate;
            }

            throw new Exception("No such element found");
        }

        private int FindCandidate(int[] nums)
        {
            var index = 0;
            var count = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[index])
                {
                    count++;
                }
                else
                {
                    count--;
                }
                if (count == 0)
                {
                    index = i;
                    count = 1;
                }
            }

            return nums[index];
        }

        public List<Tuple<int, int>> MergeOverlappingIntervals(List<Tuple<int,int>> intervals)
        {
            List<Tuple<int, int>> mergedIntervals = new List<Tuple<int, int>>();
            if (intervals == null || intervals.Count == 0)
            {
                return mergedIntervals;
            }

            intervals.Sort((x, y) => { return x.Item1.CompareTo(y.Item1); });

            var temp = intervals[0];
            for(var i=1;i<intervals.Count;i++)
            {
                if (temp.Item2 <= intervals[i].Item1)
                {
                    mergedIntervals.Add(temp);
                    temp = intervals[i];
                    continue;
                }

                int start = temp.Item1, end = temp.Item2;
                if (temp.Item1 > intervals[i].Item1)
                {
                    start = intervals[i].Item1;
                }
                if (temp.Item2 < intervals[i].Item2)
                {
                    end = intervals[i].Item2;
                }
                temp = new Tuple<int, int>(start, end);
            }
            mergedIntervals.Add(temp);
            return mergedIntervals;
        }

        public void PrintIntervals(List<Tuple<int, int>> intervals)
        {
            if (intervals == null || intervals.Count == 0)
            {
                Utility.WriteLine("Collection null or empty");
            }

            foreach (var interval in intervals)
            {
                Utility.Write("{{{0}, {1}}} ", interval.Item1, interval.Item2);
            }
            Utility.WriteLine(string.Empty);
        }

        /*
        public int RemoveBoxes(int[] boxes)
        {
            if (boxes == null || boxes.Length == 0)
            {
                return 0;
            }

            int n = boxes.Length;
            int[,] dp = new int[n,n];

            for (int len = 1; len <= n; len++)
            {
                int[,] ldp = new int[len, len + 1];
                for (int i = 0; i + len - 1 < n; i++)
                {
                    int j = i + len - 1;
                    if (len == 1)
                    {
                        dp[i, j] = 1;
                        continue;
                    }
                    {
                        bool fl = true;
                        for (int k = i + 1; k <= j; k++)
                        {
                            if (boxes[k] != boxes[i])
                            {
                                fl = false;
                                break;
                            }
                        }
                        if (fl)
                        {
                            dp[i, j] = (j - i + 1) * (j - i + 1);
                            continue;
                        }
                    }

                    int lret = 0;
                    if (boxes[i] == boxes[j])
                    {
                        for (int k = 0; k < len; k++)
                        {
                            ldp.Fill(k, int.MinValue / 2);
                        }

                        ldp[0, 1] = 0;
                        for (int k = i + 1; k <= j; k++)
                        {
                            for (int l = 1; l <= k - i + 1; l++)
                            {
                                for (int u = l + i - 1; u < k; u++)
                                {
                                    int w = ldp[u - i, l] + dp[u + 1, k];
                                    if (w > ldp[k - i, l]) ldp[k - i, l] = w;
                                }
                            }
                            if (boxes[k] == boxes[i])
                            {
                                for (int l = 0; l <= k - i; l++)
                                {
                                    ldp[k - i, l + 1] = System.Math.Max(ldp[k - i, l + 1], ldp[k - 1 - i, l]);
                                }
                            }
                        }

                        for (int l = 0; l <= j - i + 1; l++)
                        {
                            lret = System.Math.Max(lret, ldp[j - i, l] + l * l);
                        }
                    }
                    for (int k = i + 1; k <= j; k++)
                    {
                        lret = System.Math.Max(lret, dp[i, k - 1] + dp[k, j]);
                    }
                    dp[i, j] = lret;
                }
            }
            return dp[0, n - 1];
    }
    */

        List<int> value;
        List<int> length;
        int[,,] f;

        int sqr(int i)
        {
            return i * i;
        }

        int F(int i, int j, int k)
        {
            if (i == j) return sqr(length[i] + k);

            if (f[i, j, k] != -1) return f[i, j, k];
            int ans = 0;
            ans = F(i, j - 1, 0) + sqr(length[j] + k);
            for (int l = i; l < j; l++)
            {
                if (value[l] == value[j])
                {
                    ans = System.Math.Max(ans, F(i, l, length[j] + k) + F(l + 1, j - 1, 0));
                }
            }

            f[i, j, k] = ans;
            return ans;
        }

        public int RemoveBoxes(int[] boxes)
        {
            if (boxes == null || boxes.Length == 0) return 0;

            value = new List<int>();
            length = new List<int>();
            for (int i = 0, j; i < boxes.Length;)
            {
                for (j = i + 1; j < boxes.Length && boxes[i] == boxes[j]; j++) ;
                value.Add(boxes[i]);
                length.Add(j - i);
                i = j;
            }

            int m = value.Count;
            f = new int[m + 10, m + 10, boxes.Length + 10];
            for (int i = 0; i <= f.GetUpperBound(0); i++)
                for (int j = 0; j <= f.GetUpperBound(1); j++)
                    for (int k = 0; k <= f.GetUpperBound(2); k++)
                        f[i, j, k] = -1;

            return F(0, m - 1, 0);
        }
    }
}
