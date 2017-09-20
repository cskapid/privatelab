using System;
using System.Collections.Generic;

namespace Leetcode.IvBit
{
    public class LevelCheck
    {
        public void ContestValidator()
        {
            #region LongestConsecutive
            var A = new List<int>
            {
                7, 7, 8, 1, 3, 2, 4
            };
            var res = Timer.TimedFunc(() => this.LongestConsecutive(A));
            Console.WriteLine("{0} took {1} ticks. Output: {2}", "LongestConsecutive", res.TimeSpan.Ticks, res.Result);
            #endregion //LongestConsecutive


            #region Permute
            //var A = new List<int>
            //{
            //    1, 2, 3, 4, 5, 6, 7
            //};
            //var res = Timer.TimedFunc(() => this.Permute(A));
            //Console.WriteLine("{0} took {1} ticks. Output: {2}", "Permute", res.TimeSpan.Ticks, res.Result);
            #endregion //Permute

            #region NextGreater
            //var A = new List<int>
            //{
            //    //4, 5, 2, 10
            //    3, 2, 1
            //};
            //var res = Timer.TimedFunc(() => this.NextGreater(A));
            //Console.WriteLine("{0} took {1} ticks. Output: {2}", "NextGreater", res.TimeSpan.Ticks, res.Result);
            #endregion //NextGreater

            #region Subtract
            //var A = ListBuilder.BuildList(new int[]{ 1, 2, 3, 4, 5 });
            //var res = Timer.TimedFunc(() => this.Subtract(A));
            //Console.WriteLine("{0} took {1} ticks.", "Subtract", res.TimeSpan.Ticks);
            #endregion //Subtract

            #region NumRange
            //var A = new List<int> {
            //    10, 5, 1, 0, 2
            //};
            //var B = 6;
            //var C = 8;
            //var res = Timer.TimedFunc(() => this.NumRange(A, B, C));
            //Console.WriteLine("{0} took {1} ticks. Output: {2}", "NumRange", res.TimeSpan.Ticks, res.Result);
            #endregion //NumRange

            #region PrettyPrint
            //var A = 11;
            //var res = Timer.TimedFunc(() => this.PrettyPrint(A));
            //Console.WriteLine("{0} took {1}ticks", "PrettyPrint", res.TimeSpan.Ticks);
            #endregion //PrettyPrint

            #region KthSmallest
            //var A = new List<int> { 8, 16, 80, 55, 32, 8, 38, 40, 65, 18, 15, 45, 50, 38, 54, 52, 23, 74, 81, 42, 28, 16, 66, 35, 91, 36, 44, 9, 85, 58, 59, 49, 75, 20, 87, 60, 17, 11, 39, 62, 20, 17, 46, 26, 81, 92 };
            ////var A = new List<int> { 8, 80, 55, 32, 40, 65, 18, 15, 45, 50, 38, 54, 52, 23, 74, 81, 42, 28, 16, 66, 35, 91, 36, 44, 9, 85, 58, 59, 49, 75, 87, 60, 11, 39, 62, 20, 17, 46, 26, 92 };
            //var B = 9;
            //var res = Timer.TimedFunc(() => this.KthSmallestUsingMinHeap(A, B));
            //Console.WriteLine("{0} took {1} ticks. Output: {2}", "KthSmallest", res.TimeSpan.Ticks, res.Result);
            //res = Timer.TimedFunc(() => this.KthSmallestUsingMaxHeap(A, B));
            //Console.WriteLine("{0} took {1} ticks. Output: {2}", "KthSmallestUsingMaxHeap", res.TimeSpan.Ticks, res.Result);
            #endregion //KthSmallest
        }

        #region LongestConsecutive
        public int LongestConsecutive(List<int> A)
        {
            if (A == null || A.Count == 0)
            {
                return 0;
            }

            A.Sort();
            int fLen = -1;
            int curLen = 1;
            int i = 1;
            while(i < A.Count)
            {
                var diff = A[i] - A[i - 1];
                if (diff == 0)
                {
                    i++;
                    continue;
                }
                if (diff == 1)
                {
                    curLen++;
                }
                else
                {
                    fLen = Math.Max(fLen, curLen);
                    curLen = 1;

                }
                i++;
            }
            return Math.Max(fLen, curLen);
        }
        #endregion //LongestConsecutive

        #region Permute
        public List<List<int>> Permute(List<int> A)
        {
            var res = new List<List<int>>();
            if (A == null || A.Count == 0)
            {
                return res;
            }
            if (A.Count == 1)
            {
                res.Add(A);
                return res;
            }
            if (A.Count == 2)
            {
                res.Add(A);
                if (A[0] != A[1])
                {
                    res.Add(new List<int> { A[1], A[0] });
                }
                return res;
            }
            HashSet<long> set = new HashSet<long>();
            var count = A.Count;
            var fact = 1;
            while (count > 0)
            {
                fact = fact * count--;
            }
            count = A.Count;
            int fixIndex = 0;
            int j = 1;
            for(int i=0;i<fact;)
            {
                List<int> permutation = A;
                int k = 0;
                while (k != fact/count)
                {
                    while(j != count-1)
                    {
                        var hash = GetHashCode(permutation);
                        if (!set.Contains(hash))
                        {
                            set.Add(hash);
                            res.Add(permutation.ConvertAll(x => x));
                        }
                        Swap(permutation, j, j + 1);
                        k++;
                        i++;
                        j++;
                    }

                    j = 1;
                }

                fixIndex++;
                if (fixIndex == count)
                {
                    break;
                }
                Swap(permutation, 0, fixIndex);
            }
            return res;
        }

        private void Swap<T>(IList<T> list, int i, int j)
        {
            var tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
        private long GetHashCode(List<int> list)
        {
            int result = 0;
            int shift = 0;
            for (int i = 0; i < list.Count; i++)
            {
                shift = (shift + 11) % 21;
                result ^= (list[i] + 1024) << shift;
            }
            return result;
            /*
            long hash = list.Count;
            foreach (var item in list)
            {
                hash = unchecked((hash * 2147483647) + item);
            }
            return hash;
            */
        }
        #endregion //Permute

        #region PrettyPrint
        public List<List<int>> PrettyPrint(int A)
        {
            if (A <= 0)
            {
                throw new Exception("Invalid input");
            }
            int size = A + A - 1;
            List<List<int>> res = new List<List<int>>(size);
            for(int k=0;k<size;k++)
            {
                var list = new List<int>(size);
                for (int l = 0; l < size; l++)
                {
                    list.Add(0);
                }
                res.Add(list);
            }
            int num = A;
            int i = 0;
            int j = size - 1;
            while (i < j)
            {
                int n = i;
                for(int m=i;m<=j;m++)
                {
                    res[m][n] = num;
                }
                n++;
                while (n < j)
                {
                    res[i][n] = num;
                    res[j][n] = num;
                    n++;   
                }
                for (int m = i; m <= j; m++)
                {
                    res[m][n] = num;
                }

                i++;
                j--;
                num--;
            }
            res[i][j] = num;
            return res;
        }
        #endregion //PrettyPrint

        #region KthSmallest
        public int KthSmallestUsingMinHeap(List<int> A, int B)
        {
            if (A == null || B <= 0 || A.Count < B)
            {
                throw new Exception("Invalid input");
            }

            Heap<int> minHeap = new Heap<int>((k1, k2) => { return k1 < k2; });
            foreach(int i in A)
            {
                minHeap.Insert(i);
            }

            for(int i=0;i<B-1;i++)
            {
                minHeap.Pop();
            }
            return minHeap.Pop();
        }

        public int KthSmallestUsingMaxHeap(List<int> A, int B)
        {
            if (A == null || B <= 0 || A.Count < B)
            {
                throw new Exception("Invalid input");
            }

            Heap<int> maxHeap = new Heap<int>((k1, k2) => { return k1 > k2; });
            for (int i=0;i<B;i++)
            {
                maxHeap.Insert(A[i]);
            }
            for(int i=B;i<A.Count;i++)
            {
                if (A[i] <= maxHeap.Peek())
                {
                    maxHeap[0] = A[i];
                }
            }
            return maxHeap.Pop();
        }
        #endregion //KthSmallest

        #region NumRange
        public int NumRange(List<int> A, int B, int C)
        {
            if (A == null || A.Count < 0)
            {
                throw new Exception("Invalid input");
            }

            List<List<int>> rangeList = new List<List<int>>();
            int ranges = 0;
            for(int i=0;i<A.Count;i++)
            {
                if (A[i] > C)
                {
                    continue;
                }
                int sum = A[i];
                if (sum >= B)
                {
                    rangeList.Add(new List<int> { A[i] });
                    ranges++;
                }
                List<int> curRange = new List<int> { A[i] };
                for(int j=i+1;j<A.Count;j++)
                {
                    sum += A[j];
                    if (sum > C)
                    {
                        break;
                    }
                    curRange.Add(A[j]);
                    if (sum >= B)
                    {
                        rangeList.Add(curRange.ConvertAll(x => x));
                        ranges++;
                    }
                }

            }
            return ranges;
        }
        #endregion

        #region Subtract
        public ListNode Subtract(ListNode A)
        {
            if (A == null)
            {
                return null;
            }

            var root = A;
            var temp = A;
            Stack<ListNode> nodeStack = new Stack<ListNode>();
            while(temp != null)
            {
                nodeStack.Push(temp);
                temp = temp.next;
            }
            temp = A;
            while(temp != null && nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                if (temp == node)
                {
                    break;
                }
                temp.val = node.val - temp.val;
                temp = temp.next;
                if (temp == node)
                {
                    break;
                }
            }
            return root;
        }
        #endregion //Subtract

        #region NextGreater
        public List<int> NextGreater(List<int> A)
        {
            if (A == null || A.Count <= 0)
            {
                return new List<int>();
            }

            var res = new List<int>();
            for(int i=0;i<A.Count;i++)
            {
                var nextMax = -1;
                for(int j=i+1;j<A.Count;j++)
                {
                    if (A[j] > A[i])
                    {
                        nextMax = A[j];
                        break;
                    }
                }
                res.Add(nextMax);
            }
            return res;
        }
        #endregion // NextGreater
    }
}
