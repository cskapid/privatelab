using Solution.Contests;
using Solution.IvBit;
using System;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Version: {0}", Environment.Version.ToString());
            Console.WriteLine(typeof(string).Assembly.ImageRuntimeVersion);
            var sln = new Contest51();
            sln.ContestValidator();
        }
    }
}
