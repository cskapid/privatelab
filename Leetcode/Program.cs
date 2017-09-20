using Leetcode.IvBit;
using System;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Version: {0}", Environment.Version.ToString());
            Console.WriteLine(typeof(string).Assembly.ImageRuntimeVersion);
            var sln = new HeapsMaps();
            sln.ContestValidator();
        }
    }
}
