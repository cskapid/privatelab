using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.IvBit
{
    public class Arrays
    {
        public void ContestValidator()
        {
            #region FirstMissingPositive
            var input = new List<int>
            {
                //1, 2, 0
                //3, 4, -1, 1
                //-8, -7, -6
                8, 2, 5, 1, 7, 9
            };
            var res = Timer.TimedFunc(() => this.FirstMissingPositive(input));
            Console.WriteLine("{0} took {1}ticks. Output: {2}ms", "FirstMissingPositive", res.TimeSpan.Ticks, res.Result);
            #endregion //FirstMissingPositive

            #region SetZeroes
            //var input = new List<List<int>> {
            //    //new List<int> { 1, 0, 1},
            //    //new List<int> { 1, 1, 1},
            //    //new List<int> { 1, 1, 1},
            //    new List<int> { 0, 0},
            //    new List<int> { 1, 1},
            //    //new List<int> {1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0},
            //    //new List<int> {1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            //    //new List<int> {0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0},
            //    //new List<int> {0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1},
            //    //new List<int> {0, 1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1},
            //    //new List<int> {1, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0},
            //    //new List<int> {0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0},
            //    //new List<int> {1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1},
            //    //new List<int> {0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1},
            //    //new List<int> {1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1},
            //    //new List<int> {0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            //    //new List<int> {1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0},
            //    //new List<int> {1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 1},
            //    //new List<int> {0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
            //    //new List<int> {1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1},
            //    //new List<int> {0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0},
            //    //new List<int> {0, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0},
            //    //new List<int> {1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0},
            //    //new List<int> {1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1},
            //    //new List<int> {0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0},
            //    //new List<int> {1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0},
            //    //new List<int> {1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1},
            //    //new List<int> {1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0},
            //    //new List<int> {1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 1},
            //    //new List<int> {1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0},
            //    //new List<int> {0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1},
            //};
            //var res = Timer.TimedAction(() => this.SetZeroes(input));
            //Console.WriteLine("{0} took {1}ticks.", "SetZeroes", res.Ticks);
            #endregion //SetZeroes

            #region InsertInterval
            //var input = new List<KeyValuePair<int, int>>
            //{
            //    new KeyValuePair<int, int>(1, 3),
            //    new KeyValuePair<int, int>(6, 7),
            //    new KeyValuePair<int, int>(8, 10),
            //    new KeyValuePair<int, int>(13, 15)
            //};
            //var newInterval = new KeyValuePair<int, int>(
            //    //-2, 0
            //    //4,5
            //    //6, 12
            //    //5, 20
            //    //5, 14
            //    //5, 8,
            //    16, 17  
            //    );
            //var res = Timer.TimedFunc(() => this.InsertInterval(input, newInterval));
            //Console.WriteLine("{0} took {1}ticks.", "InsertInterval", res.TimeSpan.Ticks);
            #endregion //InsertInterval

            #region LargestNumber
            //var input = new List<int> {
            ////3, 30, 34, 5, 9 
            ////0, 0, 0, 0, 0
            //472, 663, 964, 722, 485, 852, 635, 4, 368, 676, 319, 412
            //};
            //var res = Timer.TimedFunc(() => this.LargestNumber1(input));
            //Console.WriteLine("{0} took {1}ticks. Output: {2}ms", "LargestNumber1", res.TimeSpan.Ticks, res.Result);
            //res = Timer.TimedFunc(() => this.LargestNumber2(input));
            //Console.WriteLine("{0} took {1}ticks. Output: {2}ms", "LargestNumber2", res.TimeSpan.Ticks, res.Result);
            //res = Timer.TimedFunc(() => this.LargestNumber(input));
            //Console.WriteLine("{0} took {1}ticks. Output: {2}ms", "LargestNumber", res.TimeSpan.Ticks, res.Result);
            #endregion //LargestNumber
        }

        #region FirstMissingPositive
        public int FirstMissingPositive(List<int> A)
        {
            if (A == null || A.Count == 0)
            {
                return 1;
            }

            A.Sort();
            int res = 1;
            for(int i=0;i<A.Count;i++)
            {
                if (A[i] < res)
                {
                    continue;
                }
                if (A[i] > res)
                {
                    return res;
                }
                res++;
            }
            return res;
         }
        #endregion //FirstMissingPositive

        #region SetZeroes
        public void SetZeroes(List<List<int>> a)
        {
            if (a == null || a.Count == 0 || a[0] == null || a[0].Count == 0)
            {
                return;
            }
            int rows = a.Count;
            int columns = a[0].Count;
            for (int k = 1; k < rows; k++)
            {
                if (a[k] == null || a[k].Count != columns)
                {
                    return;
                }
            }

            bool c0 = false;
            for (int i = 0; i < rows; i++)
            {
                if (a[i][0] == 0)
                {
                    c0 = true;
                }

                for (int j = 1; j < columns; j++)
                {
                    if (a[i][j] == 0)
                        a[i][0] = a[0][j] = 0;
                }
            }

            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = columns - 1; j >= 1; j--)
                {
                    if (a[i][0] == 0 || a[0][j] == 0)
                    {
                        a[i][j] = 0;
                    }
                }
                if (c0) a[i][0] = 0;
            }
            /*
            int i = 0;
            bool[] visited = new bool[rows * columns];
            while (i < rows)
            {
                int j = 0;
                while (j < columns)
                {
                    if (a[i][j] != 0 || visited[(i * columns) + j] == true) // Either it is a 1 or we have already cleared it to zero.
                    {
                        j++;
                        continue;
                    }
                    
                    for(int k=0;k<columns;k++)
                    {
                        if (a[i][k] == 0) continue;
                        a[i][k] = 0;
                        visited[(i * columns) + k] = true;
                    }
                    for(int k=0;k<rows;k++)
                    {
                        if (a[k][j] == 0) continue;
                        a[k][j] = 0;
                        visited[(k * columns) + j] = true;
                    }
                    j++;
                }

                i++;
            }
            */
        }
        #endregion //SetZeroes

        #region Insert
        public List<KeyValuePair<int, int>> InsertInterval(List<KeyValuePair<int, int>> intervals, KeyValuePair<int, int> newInterval)
        {
            var res = new List<KeyValuePair<int, int>>();
            if (intervals == null || intervals.Count == 0)
            {
                res.Add(newInterval);
                return res;
            }
            var i = 0;
            while (i < intervals.Count)
            {
                if (intervals[i].Key > newInterval.Value)
                {
                    res.Add(newInterval);
                    break;
                }
                if (intervals[i].Value < newInterval.Key)
                {
                    res.Add(intervals[i]);
                    i++;
                    continue;
                }
                var mergedStart = Math.Min(newInterval.Key, intervals[i].Key);
                while (i < intervals.Count && intervals[i].Key < newInterval.Value && intervals[i].Value < newInterval.Value)
                {
                    i++;
                }
                var mergedEnd = newInterval.Value;
                if (i < intervals.Count && intervals[i].Key <= newInterval.Value)
                {
                    mergedEnd = Math.Max(newInterval.Value, intervals[i++].Value);
                }
                res.Add(new KeyValuePair<int, int>(mergedStart, mergedEnd));
                break;
            }
            while (i < intervals.Count)
            {
                res.Add(intervals[i]);
                i++;
            }
            if (newInterval.Key > intervals[i-1].Value)
            {
                res.Add(newInterval);
            }
            return res;
        }
        #endregion //Insert

        #region LargestNumber
        public string LargestNumber(List<int> A)
        {
            A.Sort((a, b) => (b.ToString() + a.ToString()).CompareTo((a.ToString() + b.ToString())));
            StringBuilder result = new StringBuilder();
            foreach (int n in A)
            {
                if (n != 0)
                {
                    result.Append(n.ToString());
                }
            }
            return result.Length == 0 ? "0" : result.ToString();
        }

        public string LargestNumber1(List<int> A)
        {
            var sb = new StringBuilder();
            A.Sort((t1, t2) => {
                if (t1 == t2)
                {
                    return 0;
                }
                var m1 = GetMostSignificantDigit(t1);
                var m2 = GetMostSignificantDigit(t2);
                if (m1 == m2)
                {
                    return string.CompareOrdinal(
                        string.Format("{0}{1}", t1, t2),
                        string.Format("{1}{0}", t1, t2));
                }
                return m1 > m2 ? 1 : -1;
            } );
            var i = 0;
            sb.Append(A[i]);
            for(i=1;i<A.Count;i++)
            {
                var current = sb.ToString();
                var t1 = string.Format("{0}{1}", A[i], current);
                var t2 = string.Format("{1}{0}", A[i], current);
                if (string.CompareOrdinal(t1, t2) >= 0)
                {
                    if (A[i] != 0)
                    {
                        sb.Insert(0, A[i]);
                    }
                }
                else
                {
                    sb.Append(A[i]);
                }
            }
            return sb.ToString();
        }
        public string LargestNumber2(List<int> A)
        {
            A.Sort((t1, t2) => {
                if (t1 == t2)
                {
                    return 0;
                }
                var m1 = GetMostSignificantDigit(t1);
                var m2 = GetMostSignificantDigit(t2);
                if (m1 == m2)
                {
                    return string.CompareOrdinal(
                        string.Format("{0}{1}", t1, t2),
                        string.Format("{1}{0}", t1, t2));
                }
                return m1 > m2 ? 1 : -1;
            });
            var i = 0;
            var s = A[i].ToString();
            for (i = 1; i < A.Count; i++)
            {
                var t1 = string.Format("{0}{1}", A[i], s);
                var t2 = string.Format("{1}{0}", A[i], s);
                if (string.CompareOrdinal(t1, t2) >= 0)
                {
                    if (A[i] != 0)
                    {
                        s = t1;
                    }
                }
                else
                {
                    s = t2;
                }
            }
            return s;
        }

        private int GetMostSignificantDigit(int t)
        {
            return t.ToString()[0];
        }
        #endregion //LargestNumber
    }
}
