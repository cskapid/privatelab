using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Solution.Contests
{
    public class Contest35
    {
        public void ContestValidator()
        {
            /*
            var flowerbed = new int[] { 1, 0, 0, 0, 1 };
            var n = 1;
            var res = Timer.TimedFunc(() => this.CanPlaceFlowers(flowerbed, n));
            Debug.Assert(res.Result == true);
            Console.WriteLine("FindIntegers took {0}ms", res.TimeSpan.Milliseconds);

            n = 2;
            flowerbed = new int[] { 1, 0, 0, 0, 1 };
            res = Timer.TimedFunc(() => this.CanPlaceFlowers(flowerbed, n));
            Debug.Assert(res.Result == false);
            Console.WriteLine("FindIntegers took {0}ms", res.TimeSpan.Milliseconds);

            n = 1;
            flowerbed = new int[] { 0 };
            res = Timer.TimedFunc(() => this.CanPlaceFlowers(flowerbed, n));
            Debug.Assert(res.Result == true);
            Console.WriteLine("FindIntegers took {0}ms", res.TimeSpan.Milliseconds);

            n = 1;
            flowerbed = new int[] { 0, 0 };
            res = Timer.TimedFunc(() => this.CanPlaceFlowers(flowerbed, n));
            Debug.Assert(res.Result == true);
            Console.WriteLine("FindIntegers took {0}ms", res.TimeSpan.Milliseconds);

            n = 2;
            flowerbed = new int[] { 0, 0, 0 };
            res = Timer.TimedFunc(() => this.CanPlaceFlowers(flowerbed, n));
            Debug.Assert(res.Result == true);
            Console.WriteLine("FindIntegers took {0}ms", res.TimeSpan.Milliseconds);

            n = 1;
            flowerbed = new int[] { 1, 0, 0 };
            res = Timer.TimedFunc(() => this.CanPlaceFlowers(flowerbed, n));
            Debug.Assert(res.Result == true);
            Console.WriteLine("FindIntegers took {0}ms", res.TimeSpan.Milliseconds);

            n = 0;
            flowerbed = new int[] { 1, 1, 1 };
            res = Timer.TimedFunc(() => this.CanPlaceFlowers(flowerbed, n));
            Debug.Assert(res.Result == true);
            Console.WriteLine("FindIntegers took {0}ms", res.TimeSpan.Milliseconds);
            */
            /*
            var root = TreeBuilder.BuildTree(new int?[] { 1, 2, 3, 4 });
            var res = Timer.TimedFunc(() => this.Tree2str(root));
            Debug.Assert(res.Result == "1(2(4))(3)");
            Console.WriteLine("Tree2str took {0}ms", res.TimeSpan.Milliseconds);

            root = TreeBuilder.BuildTree(new int?[] { 1, 2, 3, null, 4 });
            res = Timer.TimedFunc(() => this.Tree2str(root));
            Debug.Assert(res.Result == "1(2()(4))(3)");
            Console.WriteLine("Tree2str took {0}ms", res.TimeSpan.Milliseconds);
            */

            var paths = new string[] { "root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)" };
            var res = Timer.TimedFunc(() => this.FindDuplicate(paths));
            Debug.Assert(res.Result.Count == 2);
            Debug.Assert(res.Result[0].Count == 3);
            Debug.Assert(res.Result[1].Count == 2);
            Console.WriteLine("FindDuplicate took {0}ms", res.TimeSpan.Milliseconds);
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (flowerbed == null || flowerbed.Length == 0)
            {
                return false;
            }
            var idx = 0;
            while(n > 0 && idx < flowerbed.Length-1)
            {
                if (flowerbed[idx] != 1)
                {
                    if (flowerbed[idx+1] == 0 && (idx == 0 ||  flowerbed[idx-1] == 0))
                    {
                        flowerbed[idx] = 1;
                        n--;
                    }
                }
                idx++;
            }
            if (n > 0 && flowerbed[idx] == 0 && (idx == 0 || flowerbed[idx - 1] == 0))
            {
                n--;
            }
            return n == 0;
        }
        public string Tree2str(TreeNode t)
        {
            if (t == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            Tree2str(t, sb);
            return sb.ToString();
        }

        private void Tree2str(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            sb.Append(node.val);
            if (node.left != null)
            {
                sb.Append("(");
                Tree2str(node.left, sb);
                sb.Append(")");
            }
            else if (node.right != null)
            {
                sb.Append("()");
            }
            if (node.right != null)
            {
                sb.Append("(");
                Tree2str(node.right, sb);
                sb.Append(")");
            }
        }

        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            var result = new List<IList<string>>();
            var fileNameContentExp = new Regex(@"(.*)\((.*)\)", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);
            foreach(var path in paths)
            {
                var splits = path.Split(' ');
                var folder = splits[0];
                for(int i=1;i<splits.Length;i++)
                {
                }
            }
            return result;
        }
        public bool IsValid(string code)
        {
            throw new NotImplementedException();
        }
    }
}
