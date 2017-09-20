using System.Collections.Generic;
using System.Linq;

namespace TestPad
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var pid = new List<int>();
            var ppid = new List<int>();
            //var pid = new int[] { 1, 3, 10, 5 };
            //var ppid = new int[] {3, 0, 5, 3 };
            pid.Add(1);
            ppid.Add(0);
            var maxVal = 25000;
            for (var i=2;i<=maxVal;i++)
            {
                pid.Add(i);
                ppid.Add(1);
            }
            var res = KillProcess(pid, ppid, 1);
            foreach (var item in res)
            {
                Utility.WriteLine(item);
            }
            */
            /*
            res = KillProcess(pid, ppid, 3);
            foreach (var item in res)
            {
                Utility.WriteLine(item);
            }
            res = KillProcess(pid, ppid, 5);
            foreach (var item in res)
            {
                Utility.WriteLine(item);
            }
            res = KillProcess(pid, ppid, 10);
            foreach (var item in res)
            {
                Utility.WriteLine(item);
            }
            res = KillProcess(pid, ppid, 0);
            foreach (var item in res)
            {
                Utility.WriteLine(item);
            }
            */
            /*
            Utility.WriteLine(MinDistance("park", "spake"));
            */
            /*
            var res = FindUnsortedSubarray(new int[] { 1, 3, 2, 3, 3 });
            Utility.WriteLine(res);
            */
            //String.StringTester.RunTests();
            //Matrix.MatrixTester.RunTests();
            //Math.MathTester.RunTests();
            //LinkedList.ListTester.RunTests();
            //Arrays.ArrayTester.RunTests();
            //Tree.TreeTester.RunTests();
            Misc.MiscTester.RunTests();
        }

        public static IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill)
        {
            var procs = new List<int>();
            if (kill == 0 && ppid.Contains(kill))
            {
                procs.AddRange(pid.Distinct());
                procs.AddRange(ppid.Distinct());
                return procs;
            }

            if (!ppid.Contains(kill))
            {
                procs.Add(kill);
                return procs;
            }
            var childProc = new List<int>();
            for(var i=0;i<ppid.Count;i++)
            {
                if (ppid[i] == kill)
                {
                    childProc.Add(pid[i]);
                    procs.Add(pid[i]);
                }
            }
            KillChildProcess(pid, ppid, childProc, procs);
            procs.Add(kill);
            return procs;
        }
        public static void KillChildProcess(IList<int> pid, IList<int> ppid, IList<int> currentSet, IList<int> procs)
        {
            var childProc = new List<int>();
            foreach(var kill in currentSet)
            {
                if (ppid.Contains(kill))
                {
                    for (var i = 0; i < ppid.Count; i++)
                    {
                        if (ppid[i] == kill)
                        {
                            childProc.Add(pid[i]);
                            procs.Add(pid[i]);
                        }
                    }
                    KillChildProcess(pid, ppid, childProc, procs);
                }
            }
        }

        public static int MinDistance(string word1, string word2)
        {
            if (word1.Equals(word2))
            {
                return 0;
            }
            if (string.IsNullOrEmpty(word1))
            {
                return word2.Length;
            }
            if (string.IsNullOrEmpty(word2))
            {
                return word1.Length;
            }

            return System.Math.Min(CalcSteps(word1, word2), CalcSteps(word2, word1));
        }

        private static int CalcSteps(string word1, string word2)
        {
            var i = 0;
            for (; i < word1.Length; i++)
            {
                var s = word1.Substring(i);
                var i1 = s.IndexOf(word2);
                if (i1 > -1)
                {
                    return (s.Length - i1) - word2.Length + i1 + i;
                }
                else
                {
                    var i2 = word2.IndexOf(s);
                    if (i2 > -1)
                    {
                        return (word2.Length - i2) - s.Length + i2 + i;
                    }
                }
            }

            return word1.Length + word2.Length;
        }

        public static int FindUnsortedSubarray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int? start = null;
            int end = -1;
            for(var i=1;i<nums.Length;i++)
            {
                if (nums[i-1] < nums[i])
                {
                    continue;
                }
                if (nums[i-1] != nums[i] && !start.HasValue)
                {
                    start = i-1;
                    end = i;
                    continue;
                }
                if ((end != -1 && nums[i - 1] == nums[i]) || nums[i - 1] > nums[i])
                {
                    end = i;
                }
            }
            if (start.HasValue)
            {
                return end - start.GetValueOrDefault() + 1;
            }

            return 0;
        }

        public IList<Point> OuterTrees(Point[] points)
        {
            return null;
        }
    }

    public class Point
    {
        public int x;
        public int y;
        public Point() { x = 0; y = 0; }
        public Point(int a, int b) { x = a; y = b; }
    }
}
