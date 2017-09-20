using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Leetcode
{
    public class Contest39
    {
        public void ContestValidator()
        {
            /*
            for (int i = 0; i <= 100; i++)
            {
                var res = Timer.TimedFunc(() => this.JudgeSquareSum(i));
                //Debug.Assert(res.Result == true);
                Console.WriteLine("JudgeSquareSum({1}) is {2}. And it took {0}ms", res.TimeSpan.Milliseconds, i, res.Result);
            }
            */

            /*
            var nums = new List<List<int>> { };
            var res = Timer.TimedFunc(() => this.SmallestRange(nums));
            //Debug.Assert(res.Result == true);
            Console.WriteLine("SmallestRange took {0}ms", res.TimeSpan.Milliseconds);
            */

            /*
            //var input = new List<int> { 6, 6, -1, -2, 3, 3, 3, 2, -10, 2, 4, 5 };
            var input = new List<int> { 1967513926, 1540383426, -1303455736, -521595368 };
            var res = Timer.TimedFunc(() => this.Maxset(input));
            Console.WriteLine("Maxset took {0}ms", res.TimeSpan.Milliseconds);
            */
            /*
            //var dim1 = new int[] { 1, 2, 3 };
            //var dim2 = new int[] { 4, 5, 6 };
            //var dim3 = new int[] { 7, 8, 9 };
            //var arr = new int[][] { dim1, dim2, dim3 };
            var dim1 = new List<int> { 1, 2, 3 };
            var dim2 = new List<int> { 4, 5, 6 };
            var dim3 = new List<int> { 7, 8, 9 };
            var input = new List<List<int>> { dim1, dim2, dim3 };
            var res = Timer.TimedFunc(() => this.SpiralOrder(input));
            Console.WriteLine("SpiralOrder took {0}ms", res.TimeSpan.Milliseconds);
            */

            /*
            var input1 = new List<int> { 4, 8, -7, -5, -13, 9, -7, 8 };
            var input2 = new List<int> { 4, -15, -10, -3, -13, 12, 8, -8 };
            var res = Timer.TimedFunc(() => this.CoverPoints(input1, input2));
            Console.WriteLine("CoverPoints took {0}ms", res.TimeSpan.Milliseconds);
            */

            /*
            var input = new List<int> { 0 };
            //var input = new List<int> { 0, 2, 0, 1, 0, 0 };
            //var input = new List<int> { -4, 7, 5, 3, 5, -4, 2, -1, -9, -8, -3, 0, 9, -7, -4, -10, -4, 2, 6, 1, -2, -3, -1, -8, 0, -8, -7, -3, 5, -1, -8, -8, 8, -1, -3, 3, 6, 1, -8, -1, 3, -9, 9, -6, 7, 8, -6, 5, 0, 3, -4, 1, -10, 6, 3, -8, 0, 6, -9, -5, -5, -6, -3, 6, -5, -4, -1, 3, 7, -6, 5, -8, -5, 4, -3, 4, -6, -7, 0, -3, -2, 6, 8, -2, -6, -7, 1, 4, 9, 2, -10, 6, -2, 9, 2, -4, -4, 4, 9, 5, 0, 4, 8, -3, -9, 7, -8, 7, 2, 2, 6, -9, -10, -4, -9, -5, -1, -6, 9, -10, -1, 1, 7, 7, 1, -9, 5, -1, -3, -3, 6, 7, 3, -4, -5, -4, -7, 9, -6, -2, 1, 2, -1, -7, 9, 0, -2, -2, 5, -10, -1, 6, -7, 8, -5, -4, 1, -9, 5, 9, -2, -6, -2, -9, 0, 3, -10, 4, -6, -6, 4, -3, 6, -7, 1, -3, -5, 9, 6, 2, 1, 7, -2, 5 };
            //var input = new List<int> { -4, -2, 0, -1, -6 };
            var res = Timer.TimedFunc(() => this.HasNobleInteger(input));
            Console.WriteLine("HasNobleInteger took {0}ms", res.TimeSpan.Milliseconds);
            */

            var input = new List<int> { 2, 5, 3, 1, 8, 1, 7, 9, 7 };
            var res = Timer.TimedFunc(() => this.Wave(input));
            Console.WriteLine("Wave took {0}ms", res.TimeSpan.Milliseconds);
        }

        public bool JudgeSquareSum(int c)
        {
            /*
            if (c < 0)
            {
                return false;
            }

            if (c == 0 || c == 1)
            {
                return true;
            }

            int root = (int) Math.Sqrt(c);
            int i = 0;
            for (;i<=root;i++)
            {
                var j = (int)Math.Sqrt(c - (i * i));
                if (c == (i * i) + (j * j))
                {
                    return true;
                }
            }

            return false;
            */

            int i = 0;
            int j = (int)Math.Sqrt(c);
            while (i <= j)
            {
                if ((i * i + j * j) < c) i++;
                else if ((i * i + j * j) > c) j--;
                else return true;
            }
            return false;
        }

        public List<int> Maxset(List<int> A)
        {
            var ret = new List<int>();
            var li1 = -1;
            var li2 = -1;
            long lsum = 0;
            var i1 = -1;
            var i2 = -1;
            long sum = 0;
            int i = 0;
            for (;i<A.Count;i++)
            {
                if (A[i] < 0)
                {
                    if (i > 0)
                    {
                        i2 = i - 1;
                    }
                    if (sum > lsum || (sum == lsum && (i2 - i1) > (li2 - li1)))
                    {
                        li1 = i1;
                        li2 = i2;
                        lsum = sum;
                    }
                    i1 = -1;
                    i2 = -1;
                    sum = 0;
                    continue;
                }

                if (i1 == -1)
                {
                    i1 = i;
                }
                sum += A[i];
            }
            if (i > 0 && A[i-1] > -1)
            {
                i2 = i - 1;
            }
            if (sum > lsum || (sum == lsum && (i2 - i1) > (li2 - li1)))
            {
                li1 = i1;
                li2 = i2;
                lsum = sum;
            }
            if (li1 != -1)
            {
                for (i = li1; i <= li2; i++)
                {
                    ret.Add(A[i]);
                }
            }

            return ret;
        }

        public List<int> SpiralOrder(List<List<int>> A)
        {
            if (A == null || A[0] == null)
            {
                return new List<int>();
            }
            var subList = A[0];
            for(var i=1;i<A.Count;i++)
            {
                if (subList.Count != A[i].Count)
                {
                    return new List<int>();
                }
            }

            int bRow = 0;
            int eRow = A.Count - 1;
            int bCol = 0;
            int eCol = A[0].Count - 1;
            var list = new List<int>(A.Count * A[0].Count);
            while (list.Count < list.Capacity)
            {
                for (int i = bCol; i <= eCol; i++)
                {
                    list.Add(A[bRow][i]);
                }
                bRow++;

                for (int i = bRow; i <= eRow; i++)
                {
                    list.Add(A[i][eCol]);
                }
                eCol--;

                if (bRow <= eRow)
                {
                    for (int i = eCol; i >= bCol; i--)
                    {
                        list.Add(A[eRow][i]);
                    }
                }
                eRow--;

                if (bCol <= eCol)
                {
                    for (int i = eRow; i >= bRow; i--)
                    {
                        list.Add(A[i][bCol]);
                    }
                }
                bCol++;
            }

            return list;
        }

        public int CoverPoints(List<int> A, List<int> B)
        {
            if (A == null || B == null || A.Count != B.Count)
            {
                throw new Exception("Invalid input");
            }
            if (A.Count == 0)
            {
                return 0;
            }

            var dist = 0;
            for(int i=1;i<A.Count;i++)
            {
                var x = Math.Abs(A[i] - A[i - 1]);
                var y = Math.Abs(B[i] - B[i - 1]);

                dist += Math.Max(x, y);
            }

            return dist;
        }

        public int HasNobleInteger(List<int> A)
        {
            if (A == null)
            {
                return -1;
            }

            A.Sort();
            var i = A.Count - 1;
            var j = i;
            var x = A[i--];
            while (i > -1)
            {
                if (x == A[i])
                {
                    i--;
                    continue;
                }
                if (x == (A.Count - 1 - j))
                {
                    return 1;
                }
                j = i;
                x = A[i--];
            }
            if (x == (A.Count - 1 - j))
            {
                return 1;
            }

            return -1;
        }

        public List<int> Wave(List<int> A)
        {
            if (A == null || A.Count <= 1)
            {
                return A;
            }

            var result = new List<int>(A.Count);
            A.Sort();
            var i = 0;
            while (i < A.Count)
            {
                if (i+1 < A.Count)
                {
                    result.Add(A[i + 1]);
                }
                result.Add(A[i]);
                i = i + 2;
            }
            return result;
        }

        public bool IsPerfectSquare(int num)
        {
            throw new NotImplementedException();
        }


        public int[] SmallestRange(IList<IList<int>> nums)
        {
            throw new NotImplementedException();
        }
    }

    public class LogSystem
    {

        public LogSystem()
        {

        }

        public void Put(int id, string timestamp)
        {

        }

        public IList<int> Retrieve(string s, string e, string gra)
        {
            throw new NotImplementedException();
        }
    }

    /**
     * Your LogSystem object will be instantiated and called as such:
     * LogSystem obj = new LogSystem();
     * obj.Put(id,timestamp);
     * IList<int> param_2 = obj.Retrieve(s,e,gra);
     */
}
