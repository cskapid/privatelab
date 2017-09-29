using System;
using System.Collections.Generic;

namespace Solution.IvBit
{
    public class HeapsMaps
    {
        public void ContestValidator()
        {
            #region LRUCache
            var cache = new LRUCache(2);
            //S 2 1 S 1 1 S 2 3 S 4 1 G 1 G 2
            cache.Set(2, 1);
            cache.Set(1, 1);
            cache.Set(2, 3);
            cache.Set(4, 1);
            Console.WriteLine(cache.Get(1));
            Console.WriteLine(cache.Get(2));
            #endregion //LRUCache

            #region DistinctNums
            //var A = new List<int> { 1, 2, 1, 3, 4, 3 };
            //var B = 3;
            //var res = Timer.TimedFunc(() => this.DistinctNums(A, B));
            //Console.WriteLine("{0} took {1}ticks", "DistinctNums", res.TimeSpan.Ticks);
            #endregion //DistinctNums

            #region MaxHeapWays
            //var A = 20;
            //var res = Timer.TimedFunc(() => this.MaxHeapWays(A));
            //Console.WriteLine("{0} took {1}ticks", "MaxHeapWays", res.TimeSpan.Ticks);
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

        #region LRUCache
        private class LRUCache
        {
            private Heap<KeyValuePair<int, long>> minHeap = new Heap<KeyValuePair<int, long>>((x, y) => { return x.Value < y.Value; });
            private Dictionary<int, int> cache = new Dictionary<int, int>();
            private int capacity;
            private long ticks = 0;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
            }

            public int Get(int key)
            {
                if (this.cache.ContainsKey(key))
                {
                    var itemIndex = this.FindHeapIndex(key);
                    this.minHeap[itemIndex] = new KeyValuePair<int, long>(key, ticks++);
                    return this.cache[key];
                }

                return -1;
            }

            public void Set(int key, int value)
            {
                var item = new KeyValuePair<int, long>(key, ticks++);
                if (this.cache.ContainsKey(key))
                {
                    var itemIndex = this.FindHeapIndex(key);
                    this.minHeap[itemIndex] = item;
                }
                else
                {
                    this.minHeap.Insert(item);
                }
                this.cache[key] = value;
                if (this.cache.Keys.Count > this.capacity)
                {
                    var lruItem = this.minHeap.Pop();
                    this.cache.Remove(lruItem.Key);
                }
            }

            private int FindHeapIndex(int key)
            {
                return this.minHeap.FindItem((data) => {
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].Key == key)
                        {
                            return i;
                        }
                    }
                    return -1;
                });
            }
        }
        #endregion //LRUCache

        #region DistinctNums
        public List<int> DistinctNums(List<int> A, int B)
        {
            if (A == null || A.Count == 0)
            {
                throw new Exception("Invalid input");
            }
            var res = new List<int>();
            if (B > A.Count)
            {
                return res;
            }
            Dictionary<int, int> presence = new Dictionary<int, int>();
            presence[A[0]] = 1;
            for(int i=1;i<A.Count;i++)
            {
                if (i >= B)
                {
                    res.Add(presence.Keys.Count);
                    presence[A[i-B]]--;
                    if (presence[A[i - B]] == 0)
                    {
                        presence.Remove(A[i - B]);
                    }
                }
                if (presence.ContainsKey(A[i]))
                {
                    presence[A[i]]++;
                }
                else
                {
                    presence[A[i]] = 1;
                }
            }
            res.Add(presence.Keys.Count);
            return res;
        }
        #endregion //DistinctNums

        #region MaxHeapWays
        private static int MAX = 1000000007;
        private static int FACT_MAX = 100;
        private int[] memo = new int[101];
        private int[] fact = new int[FACT_MAX];
        private int[] invfact = new int[FACT_MAX];

        public int MaxHeapWays(int A)
        {
            memo[0] = 1;
            memo[1] = 1;
            memo[2] = 1;
            memo[3] = 2;
            memo[4] = 3;
            memo[5] = 8;
            memo[6] = 20;
            GenFact();
            return SolveRecursively(A);
        }

        private int SolveRecursively(int A)
        {
            if (A < 0) return -1;
            if (memo[A] > 0) return memo[A];

            int right = RightHeight(A);
            memo[A] = (int)((((CalcBinomial(A - 1, right) * SolveRecursively(right)) % MAX) * SolveRecursively(A - 1 - right)) % MAX);
            return memo[A];
        }

        private int RightHeight(int A)
        {
            int h = (int)Math.Log(A, 2);
            int full = (1 << (h - 1)) - 1;
            int remaining = A - 1 - 2 * full;
            int rightLeafs = Math.Min(remaining, 1 << (h - 1));
            return full + rightLeafs;
        }

        int Add(int a, int b)
        {
            return (a + b) % MAX;
        }

        int Multiply(int a, int b)
        {
            return (int)(((long)a * b) % MAX);
        }

        int PowMod(int a, int b)
        {
            int res = 1;
            for (; b > 0; b >>= 1)
            {
                if ((b & 1) > 0) res = Multiply(res, a);
                a = Multiply(a, a);
            }
            return res;
        }

        int ModInverse(int a)
        {
            return PowMod(a, MAX - 2);
        }

        void GenFact()
        {
            fact[0] = invfact[0] = 1;
            for (int i = 1; i < FACT_MAX; i++)
            {
                fact[i] = Multiply(fact[i - 1], i);
                invfact[i] = ModInverse(fact[i]);
            }
        }

        long CalcBinomial(int n, int k)
        {
            return n < k ? 0 : Multiply(fact[n], Multiply(invfact[k], invfact[n - k]));
        }        
        /*
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
        */
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
