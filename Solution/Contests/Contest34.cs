using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Solution.Contests
{
    public class Contest34
    {
        public void ContestValidator()
        {
            /*
            //var result = this.MaxCount(18, 3, new int[,] { {16, 1},{14, 3},{14, 2},{4, 1},{10, 1},{11, 1},{8, 3},{16, 2},{13, 1},{8, 3} });
            var result = this.MaxCount(10, 10, new int[,] { {2, 1}, { 1, 2 } });
            Debug.Assert(result == 4);
            */
            /*
            var list1 = new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" };
            //var list2 = new string[] { "Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun" };
            //var list2 = new string[] { "KFC", "Shogun", "Burger King" };
            //var result = this.FindRestaurant(list1, list2);
            //Debug.Assert(result != null && result.Length == 1 && result[0] == "Shogun");
            var list2 = new string[] { "KFC", "Burger King", "Tapioca Express", "Shogun" };
            var result = this.FindRestaurant(list1, list2);
            Debug.Assert(result != null && result.Length == 4);
            */
            /*
            var nums = new int[] { 5, 4, 0, 3, 1, 6, 2 };
            var result = this.ArrayNesting(nums);
            Debug.Assert(result == 4);
            */
            /*
            var nums = new int[] { 1, 0, 2 };
            var result = this.ArrayNesting(nums);
            Debug.Assert(result == 2);
            */
            //var res = this.FindIntegers(999999999);
            //Debug.Assert(res == 2178309);
            var res = Timer.TimedFunc(() => this.FindIntegers(8));
            Debug.Assert(res.Result == 6);
            Console.WriteLine("FindIntegers took {0}ms", res.TimeSpan.Milliseconds);
        }

        public int MaxCount(int m, int n, int[,] ops)
        {
            if (m < 1 || m > 40000 || n < 1 || n > 40000)
            {
                return 0;
            }
            if (ops == null || ops.Length == 0)
            {
                return m * n;
            }

            var row = int.MaxValue;
            var col = int.MaxValue;
            for (var i = 0; i < ops.GetLength(0); i++)
            {
                row = Math.Min(row, ops[i, 0]);
                col = Math.Min(col, ops[i, 1]);
            }
            return row * col;
        }

        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            if (list1 == null || list2 == null || list1.Length == 0 || list2.Length == 0)
            {
                return null;
            }

            var list = new List<string>();
            var leastIndexSum = int.MaxValue;
            for (int i = 0; i < list1.Length; i++)
            {
                for (int j = 0; j < list2.Length; j++)
                {
                    if (list1[i] != list2[j])
                    {
                        continue;
                    }

                    var indexSum = i + j;
                    if (leastIndexSum < indexSum)
                    {
                        continue;
                    }
                    if (leastIndexSum > indexSum)
                    {
                        list.Clear();
                    }
                    leastIndexSum = indexSum;
                    list.Add(list1[i]);
                }
            }
            return list.ToArray();
        }

        public int ArrayNesting(int[] nums)
        {
            var maxSize = 0;
            if (nums == null || nums.Length == 0)
            {
                return maxSize;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                var size = 1;
                var idx = 1;
                var t = nums[i];
                while (t != i && idx < nums.Length)
                {
                    t = nums[t];
                    size++;
                }
                maxSize = Math.Max(maxSize, size);
            }

            return maxSize;
        }

        public int FindIntegers(int num)
        {
            var charArray = Convert.ToString(num, 2).ToCharArray();
            Array.Reverse(charArray);
            StringBuilder sb = new StringBuilder(new string(charArray));
            
            int n = sb.Length;

            int[] a = new int[n];
            int[] b = new int[n];

            a[0] = b[0] = 1;
            for (int i = 1; i < n; i++)
            {
                a[i] = a[i - 1] + b[i - 1];
                b[i] = a[i - 1];
            }

            int result = a[n - 1] + b[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                if (sb[i] == '1' && sb[i + 1] == '1') break;
                if (sb[i] == '0' && sb[i + 1] == '0') result -= b[i];
            }

            return result;            
            /*
            var ints = 0;
            if (num < 0)
            {
                return 0;
            }
            ints = 1;
            for (int i = 1; i <= num; i++)
            {
                var t = i & (i << 1);
                if (t == 0)
                {
                    ints++;
                }
            }

            return ints;
            */
        }
    }
}
