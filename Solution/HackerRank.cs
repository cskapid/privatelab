using System;
using System.Collections.Generic;

namespace Solution
{
    class HackerRank
    {
        static Dictionary<int, HashSet<int>> paths;

        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);

            paths = new Dictionary<int, HashSet<int>>();
            for (int a0 = 0; a0 < m; a0++)
            {
                string[] tokens_u = Console.ReadLine().Split(' ');
                int u = Convert.ToInt32(tokens_u[0]);
                int v = Convert.ToInt32(tokens_u[1]);
                AddPath(u, v);
            }

            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string[] tokens_x = Console.ReadLine().Split(' ');
                int o = Convert.ToInt32(tokens_x[0]);
                switch (o)
                {
                    case 1:
                        {
                            int x = Convert.ToInt32(tokens_x[1]);
                            int d = Convert.ToInt32(tokens_x[2]);
                            if (d == 0)
                            {
                                AddPath(x, n + 1);
                            }
                            else
                            {
                                AddPath(n + 1, x);
                            }
                            n = n + 1;
                        }
                        break;

                    case 2:
                        {
                            int x = Convert.ToInt32(tokens_x[1]);
                            int y = Convert.ToInt32(tokens_x[2]);
                            var pathExists = DoesPathExist(n, x, y);
                            if (pathExists)
                            {
                                AddPath(x, y);
                                Console.WriteLine("Yes");
                            }
                            else
                            {
                                Console.WriteLine("No");
                            }
                        }
                        break;
                }
            }
        }

        private static bool DoesPathExist(int n, int x, int y)
        {
            if (!paths.ContainsKey(x))
            {
                return false;
            }

            var visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(x);
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                if (visited[cur - 1])
                {
                    continue;
                }
                if (!paths.ContainsKey(cur))
                {
                    continue;
                }
                if (paths[cur].Contains(y))
                {
                    return true;
                }
                foreach (var i in paths[cur])
                {
                    AddPath(x, i);
                    queue.Enqueue(i);
                }
                visited[cur - 1] = true;
            }
            return false;
        }

        private static void AddPath(int u, int v)
        {
            if (paths.ContainsKey(u))
            {
                paths[u].Add(v);
            }
            else
            {
                paths.Add(u, new HashSet<int> { v });
            }
        }
    }
    /*
    using System;
    using System.Collections.Generic;
    using System.Text;

    class HackerRank
    {

        static void Main(String[] args)
        {
            const string createCmd = "crt";
            const string deleteCmd = "del";
            const string renameCmd = "rnm";
            const char createdMode = '+';
            const char deletedMode = '-';
            const char renamedMode = 'r';
            const char erroredMode = 'E';
            const string unknownCmd = "unknown command";
            const string fileNameFormat = "{0}({1})";
            const string fileRenameFormat = "{0} -> {1}";

            int q = Convert.ToInt32(Console.ReadLine());
            // Process each command
            Queue<int> removedIndex = new Queue<int>();
            var fileIndex = new Dictionary<string, int>();
            var files = new List<string>();
            for (int a0 = 0; a0 < q; a0++)
            {
                // Read the first string denoting the command type
                string command = Console.ReadLine();
                // Write additional code to read the command's file name(s) and process the command
                // Print the output string appropriate to the command
                var splits = command.Split(' ');
                var cmd = splits[0];
                switch (cmd)
                {
                    case createCmd:
                        {
                            var fileName = splits[1];
                            var fileKey = Encode(fileName);
                            var i = 1;
                            while (fileIndex.ContainsKey(fileKey))
                            {
                                fileName = string.Format(fileNameFormat, splits[1], i++);
                                fileKey = Encode(fileName);
                            }
                            if (removedIndex.Count > 0)
                            {
                                var index = removedIndex.Dequeue();
                                files[index] = fileName;
                                fileIndex.Add(fileKey, index);
                            }
                            else
                            {
                                files.Add(fileName);
                                fileIndex.Add(fileKey, files.Count - 1);
                            }
                            GenerateOutput(createdMode, fileName);
                        }
                        break;
                    case deleteCmd:
                        {
                            var fileName = splits[1];
                            var fileKey = Encode(fileName);
                            int index = fileIndex[fileKey];
                            files[index] = string.Empty;
                            fileIndex.Remove(fileKey);
                            removedIndex.Enqueue(index);
                            GenerateOutput(deletedMode, fileName);
                        }
                        break;
                    case renameCmd:
                        {
                            var oldFileName = splits[1];
                            var oldFileKey = Encode(oldFileName);
                            int index = fileIndex[oldFileKey];
                            var fileName = splits[2];
                            var fileKey = Encode(fileName);
                            var i = 1;
                            while (fileIndex.ContainsKey(fileKey))
                            {
                                fileName = string.Format(fileNameFormat, splits[2], i++);
                                fileKey = Encode(fileName);
                            }
                            fileIndex.Remove(oldFileKey);
                            files[index] = fileName;
                            fileIndex.Add(fileKey, index);
                            GenerateOutput(renamedMode, string.Format(fileRenameFormat, oldFileName, fileName));
                        }
                        break;
                    default:
                        GenerateOutput(erroredMode, unknownCmd);
                        break;
                }
            }
        }

        private static void GenerateOutput(char mode, string fileName)
        {
            const string outputFormat = "{0} {1}";
            var s = string.Format(outputFormat, mode, fileName);
            Console.WriteLine(s);
        }

        private static string Encode(string fileName)
        {
            var s = Convert.ToBase64String(Encoding.ASCII.GetBytes(fileName));
            return s.Substring(s.Length - 6);
        }
    }
    */
    /*
    using System;

    class HackerRank
    {

         //k => length of substring
         //b => base of number
         //m => modulo
        static int getMagicNumber(string s, int k, int b, int m)
        {
            if (string.IsNullOrEmpty(s) || k < 1 || k > s.Length || m < 1 || m > 1000 || b < 2 || b > 10)
            {
                return 0;
            }

            const char zero = '0';
            int sum = 0;
            for(var i=0;i<=s.Length - k; i++)
            {
                int base10 = 0;
                int j = k - 1;
                for (int i1 = 0; i1 < k; i1++)
                {
                    base10 += (s[i+i1] - zero) * (int)Math.Pow(b, j--);
                }
                sum += (base10 % m);
            }
            return sum;
        }

        static void Main(String[] args)
        {
            string s = Console.ReadLine();
            string[] tokens_k = Console.ReadLine().Split(' ');
            int k = Convert.ToInt32(tokens_k[0]);
            int b = Convert.ToInt32(tokens_k[1]);
            int m = Convert.ToInt32(tokens_k[2]);
            int result = getMagicNumber(s, k, b, m);
            Console.WriteLine(result);
        }
    }
    */
    /*
    using System;

    class HackerRank
    {

        static int solve(int[] a)
        {
            if (a == null || a.Length == 0)
            {
                return 0;
            }

            int leftSum = 0;
            int rightSum = 0;
            for(var i=0;i<a.Length/2;i++)
            {
                leftSum += a[i];
                rightSum += a[i + a.Length / 2];
            }

            return Math.Abs(leftSum - rightSum);
        }

        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int result = solve(a);
            Console.WriteLine(result);
        }
    }
    */
    /*
    using System;
    using System.Collections.Generic;

    class HackerRank
    {
        static bool IsEquationTrue(int i, int j, int k)
        {
            return ((j + 1) * (j + 1)) == (i + 1) * (k + 1);
        }

        static int geometricTrick(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int count = 0;
            int j=0;
            while(true)
            {
                j = s.IndexOf('b', j+1);
                if (j == -1)
                {
                    break;
                }
                var factors = findFactors(j+1, s.Length);
                foreach(var factor in factors)
                {
                    if (s[j] != s[factor.Key] && s[j] != s[factor.Value] && s[factor.Key] != s[factor.Value])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        static IEnumerable<KeyValuePair<int, int>> findFactors(int num, int length)
        {
            long numSqr = (long) num * (long) num;
            IList<KeyValuePair<int, int>> factors = new List<KeyValuePair<int, int>>();
            for(int i=1;i<=num;i++)
            {
                if (numSqr % i == 0)
                {
                    var j = numSqr / i;
                    if (i != j && i < length && j < length)
                    {
                        factors.Add(new KeyValuePair<int, int>((int) i-1, (int) j-1));
                    }
                }
            }

            return factors;
        }

        static void Main(String[] args)
        {
            //int n = Convert.ToInt32(Console.ReadLine());
            //string s = Console.ReadLine();
            //System.Diagnostics.Debug.Assert(s.Length == n);
            var sb = new System.Text.StringBuilder(500000);
            for(int i=0;i<16000;i++)
            {
                sb.Append('a');
            }
            for (int i = 16000; i < 34000; i++)
            {
                sb.Append('b');
            }
            for (int i = 34000; i < 49000; i++)
            {
                sb.Append('c');
            }
            for (int i = 49000; i < 50000; i++)
            {
                sb.Append('b');
            }
            //var s = "bbbbbbbbbbbbbbbbbbbbbbbaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaccccccccccccccccccccccccccccccccc"; // "ccaccbbbaccccca";
            var s = sb.ToString();
            int result = geometricTrick(s);
            Console.WriteLine(result);
        }
    }
    */
    /*
    using System;
    using System.Collections.Generic;

    class HackerRank
    {
        static int CircularWalk(int n, int s, int t, int r_0, int g, int seed, int p)
        {
            if (n == 0 || s < 0 || s >= n || t < 0 || t >= n)
            {
                return -1;
            }

            if (s == t)
            {
                return 0;
            }

            if (p < 1 || p > n || r_0 < 0 || r_0 >= p || g < 0 || g >= p || seed < 0 || seed >= p)
            {
                return -1;
            }

            int[] r = new int[n];
            r[0] = r_0;
            for(var i=1;i<n;i++)
            {
                r[i] = (r[i - 1] * g + seed) % p;
            }

            int seconds = int.MaxValue;
            bool[] vis = new bool[n];
            vis[s] = true;
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
            queue.Enqueue(new KeyValuePair<int, int>(s, 0 ));
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                var neighbours = GetNeighbours(cur.Key, n, r[cur.Key]);
                foreach(var neighbour in neighbours)
                {
                    if (vis[neighbour])
                    {
                        continue;
                    }

                    int newTime = cur.Value + 1;
                    if (neighbour == t && seconds > newTime)
                    {
                        seconds = newTime;
                    }

                    queue.Enqueue(new KeyValuePair<int, int>(neighbour, newTime));
                    vis[neighbour] = true;
                }
            }

            if (seconds == int.MaxValue)
            {
                return -1;
            }

            return seconds;
        }

        static IEnumerable<int> GetNeighbours(int cur, int n, int r)
        {
            int next = cur + r;
            int prev = cur - r;
            var neighbours = new HashSet<int>();
            for(int i=cur+1;i<=next;i++)
            {
                neighbours.Add((n+i) % n);
            }
            for(int i=prev;i<=cur-1;i++)
            {
                neighbours.Add((n + i) % n);
            }
            return neighbours;
        }

        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int s = Convert.ToInt32(tokens_n[1]);
            int t = Convert.ToInt32(tokens_n[2]);
            string[] tokens_r_0 = Console.ReadLine().Split(' ');
            int r_0 = Convert.ToInt32(tokens_r_0[0]);
            int g = Convert.ToInt32(tokens_r_0[1]);
            int seed = Convert.ToInt32(tokens_r_0[2]);
            int p = Convert.ToInt32(tokens_r_0[3]);
            int result = CircularWalk(n, s, t, r_0, g, seed, p);
            Console.WriteLine(result);
        }
    }
    */
    /*
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class HackerRank
    {
        static int GetMaxMonsters(int n, int hit, int t, int[] h)
        {
            var totalhits = t;// * hit;
            Array.Sort(h);
            var i = 0;
            while (i < h.Length && totalhits > 0)
            {
                h[i] -= hit;
                totalhits--;//= hit;
                if (h[i] <= 0)
                {
                    i++;
                }
            }

            return i;
        }

        static void Main(String[] args)
        {
            //string[] tokens_n = Console.ReadLine().Split(' ');
            //int n = Convert.ToInt32(tokens_n[0]);
            //int hit = (int) Math.Pow(10, 9); // Convert.ToInt32(tokens_n[1]);
            //int t = (int)Math.Pow(10, 9); // Convert.ToInt32(tokens_n[2]);
            //string[] h_temp = Console.ReadLine().Split(' ');
            //int[] h = Array.ConvertAll(h_temp, Int32.Parse);

            int result = GetMaxMonsters(7, 1000000000, 1000000000, new int[] { 16, 19, 7, 11, 23, 8, 16 });
            Console.WriteLine(result);
        }
    }
    */
    /*
    using System;
    using System.Collections.Generic;
    using System.Text;

    class HackerRank
    {

        static string complimentedString = string.Empty;

        static void BuildComplimentedString()
        {
            if (!string.IsNullOrEmpty(complimentedString))
            {
                return;
            }

            Dictionary<char, char> compliments = new Dictionary<char, char> { { '0', '1' }, { '1', '0' } };

            var sb = new StringBuilder();
            sb.Append("0");
            while (sb.Length < 1001)
            {
                var len = sb.Length;
                for (int j = 0; j < len && sb.Length <= 1000; j++)
                {
                    sb.Append(compliments[sb[j]]);
                }
            }

            complimentedString = sb.ToString();
        }

        static int ReceiveInput()
        {
            int i = -1;
            var input = Console.ReadLine();
            var valid = int.TryParse(input, out i);
            while (!valid || i < 0 || i > 1000)
            {
                Console.WriteLine("Invalid input {0}. Input must be number in the range of 0 to 1000. Please re-enter.", input);
                input = Console.ReadLine();
                valid = int.TryParse(input, out i);
            }

            return i;
        }

        static void Main(String[] args)
        {
            int q = -1;
            var input = Console.ReadLine();
            if (!int.TryParse(input, out q) || q < 0)
            {
                Console.WriteLine("Invalid input {0}. Input must be number greater than or equal to zero.", input);
                return;
            }

            var x = new int[q];
            for (int i = 0; i < q; i++)
            {
                x[i] = ReceiveInput();
            }

            BuildComplimentedString();
            for (int i = 0; i < q; i++)
            {
                Console.WriteLine(complimentedString[x[i]]);
            }
        }
    }
    */
}