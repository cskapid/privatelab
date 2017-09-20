using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.IvBit
{
    public class Maths
    {
        public void ContestValidator()
        {
            #region UniquePaths
            var A = 14;
            var B = 12;
            var res = Timer.TimedFunc(() => this.UniquePaths(A, B));
            Console.WriteLine("{0} took {1}ticks", "UniquePaths", res.TimeSpan.Ticks);
            #endregion //UniquePaths

            #region Arrange
            //var a = new List<int> {
            //    3, 4, 0, 2, 1
            //};
            //var res = Timer.TimedAction(() => this.Arrange(a));
            //Console.WriteLine("{0} took {1}ticks", "Arrange", res.Ticks);
            #endregion //Arrange

            #region LengthNLessThanK
            //var A = new List<int> {
            //    3, 0, 1, 5
            //};
            //var B = 3;
            //var C = 1000;
            //var res = Timer.TimedFunc(() => this.LengthNLessThanK(A, B, C));
            //Console.WriteLine("{0} took {1}ticks", "LengthNLessThanK", res.TimeSpan.Ticks);
            #endregion //LengthNLessThanK

            #region IsPalindrome
            //var A = 102301;
            //var res = Timer.TimedFunc(() => this.IsPalindrome(A));
            //Console.WriteLine("{0} took {1}ticks", "IsPalindrome", res.TimeSpan.Ticks);
            #endregion //IsPalindrome

            #region Gcd
            //var A = 350;
            //var B = 136;
            //var res = Timer.TimedFunc(() => this.Gcd(A, B));
            //Console.WriteLine("{0} took {1}ticks", "Gcd", res.TimeSpan.Ticks);
            #endregion //Gcd

            #region TitleToNumber
            //var input = "AZ";
            //var res = Timer.TimedFunc(() => this.TitleToNumber(input));
            //Console.WriteLine("{0} took {1}ticks", "TitleToNumber", res.TimeSpan.Ticks);
            #endregion //TitleToNumber

            #region PrimeSum
            //var input = 14;
            //var res = Timer.TimedFunc(() => this.PrimeSum(input));
            //Console.WriteLine("{0} took {1}ticks", "PrimeSum", res.TimeSpan.Ticks);
            #endregion //PrimeSum

            #region Sieve
            //var input = 11;
            //var res = Timer.TimedFunc(() => this.Sieve(input));
            //Console.WriteLine("{0} took {1}ticks", "Sieve", res.TimeSpan.Ticks);
            #endregion //Sieve

            #region FindDigitsInBinary
            //var input = 11;
            //var res = Timer.TimedFunc(() => this.FindDigitsInBinary(input));
            //Console.WriteLine("{0} took {1}ticks", "FindDigitsInBinary", res.TimeSpan.Ticks);
            #endregion //FindDigitsInBinary

            #region AllFactors
            //var input = 182;
            //var res = Timer.TimedFunc(() => this.AllFactors(input));
            //Console.WriteLine("{0} took {1}ticks", "AllFactors", res.TimeSpan.Ticks);
            #endregion //AllFactors
        }
        #region AllFactors
        public List<int> AllFactors(int A)
        {
            if (A < 0)
            {
                throw new Exception("Number must be non-negative");
            }
            if (A == 0) return new List<int> { 0 };
            if (A == 1) return new List<int> { 1 };
            List<int> factors = new List<int> { 1 };
            double sqrt = Math.Sqrt(A);
            int idx = 1;
            double i = 2;
            for (;i<=sqrt;i++)
            {
                int f1 = (int)i;
                if (A % f1 != 0) continue;
                factors.Insert(idx, f1);
                int f2 = A / (int) i;
                if (f1 != f2)
                {
                    factors.Insert(factors.Count - idx + 1, f2);
                }
                idx++;

            }
            factors.Add(A);
            return factors;
        }
        #endregion //AllFactors

        #region FindDigitsInBinary
        public string FindDigitsInBinary(int A)
        {
            if (A < 0)
            {
                throw new Exception("Expected output is Assume this problem is limited to positive integers");
            }
            StringBuilder sb = new StringBuilder();
            while (A > 1)
            {
                sb.Insert(0, A % 2);
                A = A / 2;
            }
            sb.Insert(0, A);
            return sb.ToString();
        }
        #endregion //FindDigitsInBinary

        #region Sieve
        public List<int> Sieve(int A)
        {
            var res = new List<int>();
            for(int i=2;i<=A;i++)
            {
                if (IsPrime(i))
                {
                    res.Add(i);
                }
            }
            return res;
        }
        #endregion //Sieve

        #region PrimeSum
        public List<int> PrimeSum(int A)
        {
            if (A % 2 != 0)
            {
                throw new Exception("Only even numbers allowed");
            }

            List<int> res = new List<int>();
            if (A <= 2)
            {
                return res;
            }
            for(int i =2; i<=A/2;i++)
            {
                if (IsPrime(i))
                {
                    int j = A - i;
                    if (IsPrime(j))
                    {
                        res.Add(i);
                        res.Add(j);
                        break;
                    }
                }
            }
            return res;
        }

        private bool IsPrime(int n)
        {
            double sqrt = Math.Sqrt(n);
            double i = 2;
            for (; i <= sqrt; i++)
            {
                int f1 = (int)i;
                if (n % f1 == 0) return false;
            }

            return true;
        }
        #endregion //PrimeSum

        #region TitleToNumber
        public int TitleToNumber(string A)
        {
            int res = 0;
            if (string.IsNullOrEmpty(A.Trim()))
            {
                return res;
            }

            var exMsg = "Invalid Input! All characters should be A-Z";
            int first = (int)'A';
            int multiplier = 1; 
            for(int i=A.Length-1;i>=0;i--)
            {
                int cur = (int)A[i] - first + 1;
                if (cur < 1 || cur > 26)
                {
                    throw new Exception(exMsg);
                }

                res += cur * multiplier;
                multiplier *= 26;
            }
            return res;
        }
        #endregion //TitleToNumber

        #region Gcd
        public int Gcd(int A, int B)
        {
            if (A <0 || B < 0)
            {
                throw new Exception("Invalid Input! Assume m and n are non negative!");
            }
            if (A == 0 && B == 0)
            {
                return 0;
            }
            if (A == 0)
            {
                return B; 
            }
            if (B == 0)
            {
                return A;
            }

            var min = Math.Min(A, B);
            int sqrt = (int)Math.Floor(Math.Sqrt(min));
            int i = 1;
            int? l = null;
            for (; i <= sqrt; i++) {
                if (A % i == 0 && B % i == 0)
                {
                    l = Math.Max(i, l.GetValueOrDefault());
                }

                var d = (min / i);
                if (A % d == 0 && B % d == 0)
                {
                    return d;
                }
            }
            return l.Value;
        }
        #endregion //Gcd

        #region IsPalindrome
        public int IsPalindrome(int A)
        {
            if (A < 0)
            {
                return 0;
            }

            int s = 0;
            double multiplier = 0.1;
            int B = A;
            while(A > 0)
            {
                A /= 10;
                multiplier *= 10;
            }
            A = B;
            while (A > 0)
            {
                s += (A % 10) * (int) multiplier;
                multiplier /= 10;
                A /= 10;
            }
            if (s == B)
            {
                return 1;
            }
            return 0;
        }
        #endregion //IsPalindrome

        #region LengthNLessThanK
        /*
        public int LengthNLessThanK(List<int> A, int B, int C)
        {
            if (A == null || A.Count == 0)
            {
                return 0;
            }

            foreach (var n in A)
            {
                if (n < 0 || n > 9)
                {
                    throw new Exception("Invalid input");
                }
            }

            if (B < 1 || B > 9)
            {
                throw new Exception("Invalid input");
            }

            if (C < 0 || C > 1e9)
            {
                throw new Exception("Invalid input");
            }

            if (C == 0)
            {
                return 0;
            }

            double multiplier = 0.1;
            int i = 1;
            for (; i <= B; i++)
            {
                multiplier *= 10;
            }
            A.Sort();
            int ct = 0;
            int tot = 0;
            ct = WorkRecursively(A, C, (int) multiplier, ct, tot);
            return ct;
        }

        private int WorkRecursively(List<int> A, int C, int multiplier, int ct, int tot)
        {
            int t1 = ct;
            int i = A.Count - 1;
            while (i >= 0)
            {
                int maxVal = Math.Min(C, (int)(((A[A.Count - 1] + 1) * multiplier) - 1));
                int msb = (int)Char.GetNumericValue(maxVal.ToString()[0]);
                if (A[i] > msb)
                {
                    i--;
                    continue;
                }

                int t2 = tot + (A[i] * multiplier);
                if (t2 == 0 & multiplier > 1)
                {
                    break;
                }
                if (t2 < C)
                {
                    if (multiplier != 1)
                    {
                        t1 = WorkRecursively(A, C, (int)(multiplier / 10), t1, t2);
                    }
                    else
                    {
                        t1++;
                    }
                }
                i--;
            }

            return t1;
        }
        */
        public int LengthNLessThanK(List<int> A, int B, int C)
        {
            if (A.Count == 0) return 0;

            List<int> C2 = new List<int>();

            int v = C;
            while (v > 0)
            {
                C2.Add(v % 10);
                v /= 10;
            }

            if (C2.Count < B)
            {
                return 0;
            }
            if (C2.Count > B)
            {
                if (B == 1) return A.Count;
                int c = A[0] == 0 ? A.Count - 1 : A.Count;
                for (int i = 1; i < B; i++)
                {
                    c *= A.Count;
                }

                return c;
            }
            return WorkRecursively(A, C2.Count - 1, C2);
        }
        private int WorkRecursively(List<int> A, int i, List<int> C)
        {
            int j = 0;
            while (j < A.Count && A[j] < C[i])
            {
                j++;
            }

            int res = (i != C.Count - 1 || A[0] != 0 || C.Count == 1) ? j : j - 1;

            for (int k = i; res != 0 && k > 0; k--)
            {
                res *= A.Count;
            }

            if (i > 0 && (j < A.Count && A[j] == C[i]))
            {
                res += WorkRecursively(A, i - 1, C);
            }
            return res;
        }
        #endregion //LengthNLessThanK

        #region Arrange
        //Rearrange a given array so that Arr[i] becomes Arr[Arr[i]] with O(1) extra space.
        public void Arrange(List<int> A)
        {
            int n = A.Count;
            for (int i = 0; i < n; i++)
            {
                A[i] = A[i] + (A[A[i]] % n) * n;
            }
            for (int i = 0; i < n; i++)
            {
                A[i] = A[i] / n;
            }

        }
        #endregion //Arrange

        #region UniquePaths
        public int UniquePaths(int A, int B)
        {
            long ans = 1;
            for (int i = B; i < (A + B - 1); i++)
            {
                ans *= i;
                ans /= (i - B + 1);
            }
            return (int)ans;
            /*
            if (A < 0 || B < 0)
            {
                throw new Exception("Invalid input");
            }

            if (A == 0 || B == 0)
            {
                return 1;
            }

            int paths = 0;
            Dictionary<Tuple, bool> history = new Dictionary<Tuple, bool>();
            Queue<Tuple> queue = new Queue<Tuple>();
            queue.Enqueue(new Tuple(0, 0));
            while (queue.Count > 0)
            {
                var pt = queue.Dequeue();
                if (pt.Item1 == A-1 && pt.Item2 == B-1)
                {
                    paths++;
                    continue;
                }
                var n = pt.Item1 + 1;
                if (n < A)
                {
                    var item = new Tuple(n, pt.Item2);
                    if (!history.ContainsKey(item) || !history[item])
                    {
                        queue.Enqueue(item);
                    }
                }
                n = pt.Item2 + 1;
                if (n < B)
                {
                    var item = new Tuple(pt.Item1, n);
                    if (!history.ContainsKey(item) || !history[item])
                    {
                        queue.Enqueue(item);
                    }
                }
            }
            return paths;
            */
        }
        public class Tuple
        {
            public int Item1 { get; set; }
            public int Item2 { get; set; }

            public Tuple()
            {

            }

            public Tuple(int a, int b)
            {
                this.Item1 = a;
                this.Item2 = b;
            }
        }
        #endregion //UniquePaths
    }
}
