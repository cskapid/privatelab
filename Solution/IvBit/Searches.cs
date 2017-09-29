using System;
using System.Collections.Generic;

namespace Solution.IvBit
{
    public class Searches
    {
        public void ContestValidator()
        {
            #region FindMedian
            var a = new List<List<int>> {
                new List<int> { 1, 3, 6 },
                new List<int> { 2, 6, 9 },
                new List<int> { 3, 6, 9 },
            };
            var res = Timer.TimedFunc(() => this.FindMedian(a));
            Console.WriteLine("{0} took {1}ticks. Output: {2}", "FindMedian", res.TimeSpan.Ticks, res.Result);
            #endregion //FindMedian

            #region PowDivider
            //var x = 2;
            //var n = 3;
            //var d = 3;
            //var res = Timer.TimedFunc(() => this.PowDivider(x, n, d));
            //Console.WriteLine("{0} took {1}ticks. Output: {2}", "PowDivider", res.TimeSpan.Ticks, res.Result);
            #endregion //PowDivider

            #region SearchMatrix
            //var a = new List<List<int>> {
            //    new List<int> { 1,   3,  5,  7, 9 },
            //    new List<int> { 10, 11, 16, 20, 23 },
            //    new List<int> { 23, 30, 34, 50, 55 },
            //};
            //var b = 8;
            //var res = Timer.TimedFunc(() => this.SearchMatrix(a, b));
            //Console.WriteLine("{0} took {1}ticks. Output: {2}", "SearchMatrix", res.TimeSpan.Ticks, res.Result);
            #endregion //SearchMatrix

            #region Sqrt
            //var a = 740819855;
            //var res = Timer.TimedFunc(() => this.Sqrt(a));
            //Console.WriteLine("{0} took {1}ticks", "Sqrt", res.TimeSpan.Ticks);
            #endregion //Sqrt

            #region FindMin
            //var a = new List<int> { 7, 8, 9, 9, 9, 4, 5, 6 };
            //var res = Timer.TimedFunc(() => this.FindMin(a));
            //Console.WriteLine("{0} took {1}ticks", "FindMin", res.TimeSpan.Ticks);
            #endregion //FindMin

            #region FindCount
            //var A = new List<int> {
            //    5, 7, 7, 8, 8, 10
            //};
            //var B = 8;
            //var res = Timer.TimedFunc(() => this.FindCount(A, B));
            //Console.WriteLine("{0} took {1}ticks", "FindCount", res.TimeSpan.Ticks);
            #endregion //FindCount
        }

        #region FindCount
        public int FindCount(List<int> A, int B)
        {
            int cnt = 0;
            if (A == null || A.Count == 0)
            {
                return cnt;
            }

            FindCountRecursively(A, B, 0, A.Count - 1, ref cnt);
            return cnt;
        }

        public void FindCountRecursively(List<int> A, int B, int start, int end, ref int cnt)
        {
            if (start >= end)
            {
                if (A[start] == B)
                {
                    cnt++;
                }
                return;
            }
            int midPt = start + ((end - start) / 2);
            if (A[midPt] >= B)
            {
                FindCountRecursively(A, B, start, midPt, ref cnt);
            }
            if (A[midPt] <= B)
            {
                FindCountRecursively(A, B, midPt + 1, end, ref cnt);
            }
        }
        #endregion //FindCount

        #region FindMin
        public int FindMin(List<int> A)
        {
            if (A == null || A.Count == 0)
            {
                throw new Exception("Invalid input");
            }

            int? min = null;
            FindMinRecursively(A, 0, A.Count - 1, ref min);
            return min.Value;
        }
        public void FindMinRecursively(List<int> A, int start, int end, ref int? min)
        {
            if (start >= end)
            {
                if (min == null)
                {
                    min = A[start];
                }
                else
                {
                    min = Math.Min(min.Value, A[start]);
                }
                return;
            }
            int midPt = start + ((end - start) / 2);
            if (A[midPt] > A[end])
            {
                FindMinRecursively(A, midPt + 1, end, ref min);
            }
            else
            {
                FindMinRecursively(A, start, midPt, ref min);
            }
        }
        #endregion //FindMin

        #region Sqrt
        public int Sqrt(int A)
        {
            int low, high, root;
            int mid;

            low = 1;
            high = A;
            root = 0;

            while (low <= high)
            {

                mid = (low + high) / 2;

                if (mid == A / mid && (A % mid == 0))
                    return mid;

                if (mid <= A / mid)
                {
                    root = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }

            }

            return root;
            /*
            if (a == 0 || a == 1)
            {
                return a;
            }
            double start = 0;
            double end = a;
            double mid = 0;
            var min_range = 0.0000000000000001;

            while ((end - start) > min_range)
            {
                mid = (start + end) / 2.0;
                var sqr = mid * mid;
                if (Math.Abs(sqr - a) <= min_range)
                {
                    return (int)mid;
                }
                else if (sqr < a)
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }

            }

            return (int) mid;
            */
        }
        #endregion //Sqrt

        #region SearchMatrix
        public int SearchMatrix(List<List<int>> a, int b)
        {
            int res = 0;
            if (a == null || a.Count == 0)
            {
                return res;
            }
            int rows = a.Count;
            int columns = a[0].Count;
            int i = 0;
            int j = rows - 1;
            while (i <= j)
            {
                int mid = (i + j) / 2;
                if (a[mid][0] <= b && a[mid][columns - 1] >= b)
                {
                    return SearchList(a[mid], b);
                }
                if (a[mid][0] > b)
                {
                    j = mid - 1;
                }
                else
                {
                    i = mid + 1;
                }

            }

            return res;
        }

        private int SearchList(List<int> a, int b)
        {
            int i, j;

            i = 0;
            j = a.Count - 1;

            while (i <= j)
            {

                int mid = (i + j) / 2;

                if (a[mid] == b)
                {
                    return 1;
                }
                if (a[mid] < b)
                {
                    i = mid + 1;
                }
                else
                {
                    j = mid - 1;
                }
            }

            return 0;
        }
        #endregion //SearchMatrix

        #region PowDivider
        public int PowDivider(int x, int n, int d)
        {
            //NAIVE
            // if(x < 0) {
            //     x *= -1;
            // }

            // while(n > 0) {
            //     x *= x;
            //     n--;
            // }

            // if(x == 0) {
            //     return 0;
            // }

            // if(x < d) {
            //     return d - x;
            // }


            // while(x > d) {
            //     x -= d;
            // }

            // return x; 

            long rem = 1;
            int check = 0;

            // simple cases
            if (x == 0)
            {
                return 0;
            }
            if (n == 0)
            {
                return 1;
            }

            // make x positive, check if power is odd
            if (x < 0)
            {
                x = Math.Abs(x);
                if (n % 2 != 0)
                {
                    check = 1;
                }
            }

            long temp = x % d;

            while (n != 0)
            {
                if (n % 2 != 0)
                {
                    rem = (rem * temp) % d;
                }

                temp = temp * temp;
                temp = temp % d;

                n = n / 2;
                if (rem > d)
                {
                    rem = rem % d;
                }
            }

            // if power is odd and x < 0, return d-rem
            if (check == 1)
            {
                return d - (int)rem;
            }

            return (int)rem;
        }
        #endregion //PowDivider

        #region FindMedian
        public int FindMedian(List<List<int>> A)
        {
            if (A == null || A.Count == 0 || A[0] == null || A[0].Count == 0)
            {
                throw new Exception("Invalid input");
            }

            int rows = A.Count;
            int columns = A[0].Count;
            foreach (var item in A)
            {
                if (item == null || item.Count != columns)
                {
                    throw new Exception("Invalid input");
                }
            }

            int max = int.MinValue;
            int min = int.MaxValue;

            for (int i = 0; i < rows; i++)
            {

                // Finding the minimum element
                if (A[i][0] < min)
                    min = A[i][0];

                // Finding the maximum element
                if (A[i][columns - 1] > max)
                    max = A[i][columns - 1];
            }

            int desired = (rows * columns + 1) / 2;
            while (min < max)
            {
                int mid = min + (max - min) / 2;
                int place = 0;
                int get = 0;

                // Find count of elements smaller than mid
                for (int i = 0; i < rows; ++i)
                {

                    get = A[i].BinarySearch(mid);

                    // If element is not found in the array the 
                    // binarySearch() method returns 
                    // (-(insertion_point) - 1). So once we know 
                    // the insertion point we can find elements
                    // Smaller than the searched element by the 
                    // following calculation
                    if (get < 0)
                        get = Math.Abs(get) - 1;

                    // If element is found in the array it returns 
                    // the index(any index in case of duplicate). So we go to last
                    // index of element which will give  the number of 
                    // elements smaller than the number including 
                    // the searched element.
                    else
                    {
                        while (get < A[i].Count && A[i][get] == mid)
                            get += 1;
                    }

                    place = place + get;
                }

                if (place < desired)
                    min = mid + 1;
                else
                    max = mid;
            }
            return min;
        }
        #endregion //FindMedian
    }
}

