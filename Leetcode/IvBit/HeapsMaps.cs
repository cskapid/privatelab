using System;
using System.Collections.Generic;

namespace Leetcode.IvBit
{
    public class HeapsMaps
    {
        public void ContestValidator()
        {
            #region MaxHeapWays
            var A = 20;
            var res = Timer.TimedFunc(() => this.MaxHeapWays(A));
            Console.WriteLine("{0} took {1}ticks", "MaxHeapWays", res.TimeSpan.Ticks);
            #endregion MaxHeapWays

            #region MaxPairCombinations
            //var A = new List<int>
            //{
            //    1, 4, 2, 3
            //    //2, 5, 1, 6
            //    //1, 2, 3, 4
            //};
            //var B = new List<int>
            //{
            //    2, 5, 1, 6
            //    //1, 4, 2, 3
            //    //5, 6, 7, 8
            //};
            //var res = Timer.TimedFunc(() => this.MaxPairCombinations(A, B));
            //Console.WriteLine("{0} took {1}ticks. Output: {2}ms", "MaxPairCombinations", res.TimeSpan.Ticks, res.Result);
            #endregion //Solve
        }

        #region MaxHeapWays
        public int MaxHeapWays(int A)
        {
            if (A <= 2)
            {
                return 1;
            }

            ulong[] a = new ulong[A+1];
            a[0] = 1;
            a[1] = 1;

            ulong n = 2;
            for (; n <= (ulong) A; n++)
            {
                var h = Math.Floor(Math.Log((n + 1), 2) - 1);
                var h2 = Math.Pow(2, h);
                var b = h2 - 1;
                var r = n - 1 - 2 * b;
                var r1 = r - Math.Floor(r / h2) * (r - h2);
                var r2 = r - r1;
                a[n] = Binomial(n - 1, (ulong) (b + r1)) * (ulong) a[(int) (b + r1)] * (ulong) a[(int) (b + r2)];

                    /*var h = (ulong) (Math.Floor(Math.Log(2, n + 1)) - 1);
                var b = (ulong)(Math.Pow(2, h) - 1);
                var r = (ulong) (n - 1 - 2 * b);
                var r1 = (ulong) (r - Math.Floor(r / Math.Pow(2, h)) * (r - Math.Pow(2, h)));
                var r2 = r - r1;
                a[n] = Binomial((n - 1), (b + r1)) * a[b + r1] * a[b + r2];*/
            }

            //Table[a[n], { n, 0, 26}]
            return (int) a[A];
        }

        private ulong Binomial(ulong n, ulong k)
        {
            if (n < k)
                return 0;

            ulong Numerator = 1;
            for (ulong i = n; i > k; i--)
            {
                Numerator *= i;
            }
            ulong Demoninator = Factorial(n - k);
            return (Numerator / Demoninator);
        }

        private ulong Factorial(ulong n)
        {
            ulong Result = 1;
            for (ulong i = 1; i <= n; i++)
            {
                Result *= i;
            }
            return Result;
        }
        #endregion MaxHeapWays

        #region Solve
        class Tuple
        {
            public int Ai { get; set; }
            public int Bi { get; set; }

            public Tuple()
            {

            }

            public Tuple(int a, int b)
            {
                this.Ai = a;
                this.Bi = b;
            }
        }

        public List<int> MaxPairCombinations(List<int> A, List<int> B)
        {
            List<int> ret = new List<int>();
            SortedList<int, IList<Tuple>> heap = new SortedList<int, IList<Tuple>>();
            HashSet<string> s = new HashSet<string>();
            A.Sort();
            B.Sort();
            int ai = A.Count - 1;
            int bi = B.Count - 1;
            int n = A.Count;
            int sum = A[ai] + B[bi];
            heap.Add(-sum, new List<Tuple> { new Tuple() { Ai = ai, Bi = bi, } });
            s.Add(ai + "#" + bi);
            while (ret.Count != n && heap.Count > 0)
            {
                int key = heap.Keys[0];
                IList<Tuple> ts = heap[key];
                heap.RemoveAt(0);

                for (int i = 0; i < ts.Count && ret.Count != n; i++)
                {
                    ret.Add(-key);
                    Tuple t = ts[i];
                    ai = t.Ai;
                    bi = t.Bi;
                    if (ai - 1 >= 0)
                    {
                        if (!s.Contains((ai - 1) + "#" + bi))
                        {
                            sum = -(A[ai - 1] + B[bi]);

                            if (!heap.ContainsKey(sum))
                            {
                                heap.Add(sum, new List<Tuple>());
                            }

                            heap[sum].Add(new Tuple { Ai = ai - 1, Bi = bi, });
                            s.Add((ai - 1) + "#" + bi);
                        }
                    }

                    if (bi - 1 >= 0)
                    {
                        if (!s.Contains(ai + "#" + (bi - 1)))
                        {
                            sum = -(A[ai] + B[bi - 1]);

                            if (!heap.ContainsKey(sum))
                            {
                                heap.Add(sum, new List<Tuple>());
                            }

                            heap[sum].Add(new Tuple { Ai = ai, Bi = bi - 1, });
                            s.Add(ai + "#" + (bi - 1));
                        }
                    }
                }
            }
            return ret;
        }
        
        //public List<int> MaxPairCombinationsOld(List<int> A, List<int> B)
        //{
        //    if (A == null || B == null || A.Count == 0 || A.Count != B.Count)
        //    {
        //        throw new Exception("Invalid input format OR invalid test case.");
        //    }

        //    A.Sort();
        //    B.Sort();
        //    List<int> res = new List<int>(A.Count-1);
        //    int i = A.Count - 1;
        //    int j = B.Count - 1;
        //    res.Add(A[i] + B[j]);
        //    while (i >= 0 && j >= 0 && res.Count < A.Count)
        //    {
        //        if (A[i] + B[j] > A[j] + B[i])
        //        {
        //            i--;
        //        }
        //        else if (A[i] + B[j] < A[j] + B[i])
        //        {
        //            j--;
        //        }
        //        else
        //        {
        //            if (A[i - 1] + B[j] >= A[i] + B[j - 1])
        //            {
        //                i--;
        //            }
        //            else
        //            {
        //                j--;
        //            }
        //        }
        //        res.Add(A[i] + B[j]);

        //        //if (A[i-1] + B[j] > A[i] + B[j -1])
        //        //{
        //        //    i--;
        //        //}
        //        //else
        //        //{
        //        //    j--;
        //        //}


        //        /*
        //        if (A[i] > B[j])
        //        {
        //            if (A[i-1] >= B[j])
        //            {
        //                i--;
        //                continue;
        //            }
        //            else
        //            {
        //                j--;
        //                i = A.Count - 1;
        //                continue;
        //            }
        //        }

        //        if (B[j] > A[i])
        //        {
        //            if (B[j - 1] >= A[i])
        //            {
        //                j--;
        //                continue;
        //            }
        //            else
        //            {
        //                i--;
        //                j = B.Count - 1;
        //                continue;
        //            }
        //        }*/
        //    }
        //    return res;
        //}
        #endregion //Solve
    }
}
