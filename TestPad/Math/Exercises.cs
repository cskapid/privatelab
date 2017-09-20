using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TestPad.Math
{
    using Metadata = System.Tuple<double, string, double, string>;

    public class Exercises
    {
        IDictionary<string, Metadata> dictionary = new Dictionary<string, Metadata>();
        /*
        public string OptimalDivision(int[] nums)
        {
            return Execute(nums, 0, nums.Length - 1).Item4;
        }

        public Metadata Execute(int[] nums, int start, int end)
        {
            string key = start + " " + end;
            if (this.dictionary.ContainsKey(key)) return this.dictionary[key];

            if (start == end) return new Metadata(nums[start], "" + nums[start], nums[start], "" + nums[start]);

            var result = new Metadata(0, "", 0, "");

            for (int i = start; i < end; i++)
            {
                var left = Execute(nums, start, i);
                var right = Execute(nums, i + 1, end);

                var min = left.Item1 / right.Item3;
                var minS = left.Item2 + "/" + (i + 1 == end ? right.Item4: "(" + right.Item4 + ")");
                var max = left.Item3 / right.Item1;
                var maxS = left.Item4 + "/" + (i + 1 == end ? right.Item2 : "(" + right.Item4 + ")");
                if (result.Item1 == 0 || min < result.Item1)
                {
                    result.Item1 = min;
                    result.Item2 = minS;
                }
                if (max > result.Item3)
                {
                    result.Item3 = max;
                    result.Item4 = maxS;
                }
            }
            this.dictionary[key] = result;
            return result;
        }
        */
        public int ConvertToSingleDigit(int num)
        {
            return 1 + ((num - 1) % 9);
        }

        public bool IsHappy(int n)
        {
            if (n == 0)
            {
                return false;
            }

            var next = n;
            var secondnext = n;
            do
            {
                if (next == 1 || secondnext == 1)
                {
                    return true;
                }
                next = SquareTheDigits(next);
                secondnext = SquareTheDigits(SquareTheDigits(secondnext));
            } while (next != secondnext);

            if (next == 1 || secondnext == 1)
            {
                return true;
            }

            return false;
        }

        public bool IsHappyWithSet(int n)
        {
            if (n == 0)
            {
                return false;
            }

            var m = n;
            var prevNumbers = new HashSet<int>();
            prevNumbers.Add(m);
            var result = true;
            while (m != 1)
            {
                var square = SquareTheDigits(m);
                Utility.Write("{0} ", square);
                if (!prevNumbers.Add(square))
                {
                    result = false;
                    break;
                }
                m = square;
            }

            return result;
        }

        public int SquareTheDigits(int n)
        {
            var m = n;
            var sum = 0;
            while (m > 0)
            {
                var mod = m % 10;
                sum = sum + (mod * mod);
                m = m / 10;
            }
            return sum;
        }

        const int BatchSize = 10;
        private HashSet<uint> perfectNumbers;

        private uint lastPerfectNumber;

        public bool CheckPerfectNumber(int num)
        {
            if (num <= 1 || (num % 2 != 0))
            {
                return false;
            }
            for(var i=2; i * i < num; i++)
            {
                var sum = (System.Math.Pow(2, i - 1) * (System.Math.Pow(2, i) - 1));
                if (sum == num) return true;
                if (sum > num) return false;
            }
            return false;
           // while (BuildPerfectNumbers(BatchSize, num) && lastPerfectNumber < num) ;
           // return perfectNumbers.Contains((uint)num);
        }

        private bool BuildPerfectNumbers(int count, int maxNumber)
        {
            if (perfectNumbers == null)
            {
                perfectNumbers = new HashSet<uint>();
            }
            var currentCount = perfectNumbers.Count + 1;
            for (var i = currentCount; i < currentCount + count; i++)
            {
                var num = (uint)(System.Math.Pow(2, i - 1) * (System.Math.Pow(2, i) - 1));
                if (num > maxNumber)
                {
                    return false;
                }
                perfectNumbers.Add(num);
                lastPerfectNumber = num;
            }
            return true;
        }

        const string ComplexNumberPattern = @"(-?\d*)\+(-?\d*)i";

        public string ComplexNumberMultiply(string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b))
            {
                return string.Empty;
            }

            var ret = new ComplexNumber(a) * new ComplexNumber(b);
            return ret.ToString();
        }

        private class ComplexNumber
        {
            public int Real { get; set; }
            public int Imaginary { get; set; }

            public ComplexNumber(string complexNumber)
            {
                Regex regex = new Regex(ComplexNumberPattern, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);
                var splits = regex.Split(complexNumber);
                this.Real = int.Parse(splits[1]);
                this.Imaginary = int.Parse(splits[2]);
            }

            public ComplexNumber(int real, int img)
            {
                this.Real = real;
                this.Imaginary = img;
            }

            public static ComplexNumber operator*(ComplexNumber c1, ComplexNumber c2)
            {
                var realPart = c1.Real * c2.Real + -(c1.Imaginary * c2.Imaginary);
                var imgPart = c1.Real * c2.Imaginary + c1.Imaginary * c2.Real;
                return new ComplexNumber(realPart, imgPart);
            }

            public override string ToString()
            {
                return string.Format("{0}+{1}i", this.Real, this.Imaginary);
            }

            public void Print()
            {
                Utility.WriteLine(string.Format("{0}+{1}i", this.Real, this.Imaginary));
            }
        }
    }
}
