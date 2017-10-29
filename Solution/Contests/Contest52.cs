using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Contests
{
    public class Contest52
    {
        public void ContestValidator()
        {
            #region RepeatedStringMatch
            /*
            var A = "abababaaba"; // "abcd"; 
            var B = "aabaaba"; // "cdabcdab";
            var res = Timer.TimedFunc(() => this.RepeatedStringMatch(A, B));
            Console.WriteLine("{0} took {1} ticks.", "RepeatedStringMatch", res.TimeSpan.Ticks);
            */
            #endregion //RepeatedStringMatch

            #region LongestUnivaluePath
            //var tree = TreeBuilder.BuildTree(new int?[] {
            //    //5, 4, 5, 1, 1, null, 5
            //    //1, 4, 5, 4, 4, 5, 5, null, null, null, null, 5
            //    1, 4, 5, 4, 4, 5, 5, 4, 4, null, null, 5
            //});
            //var res = Timer.TimedFunc(() => this.LongestUnivaluePath(tree));
            //Console.WriteLine("{0} took {1} ticks.", "LongestUnivaluePath", res.TimeSpan.Ticks);
            #endregion //RepeatedStringMatch

            #region KnightProbability
            int N = 0;
            int K = 0;
            int r = 0;
            int c = 0;
            var res = Timer.TimedFunc(() => this.KnightProbability(N, K, r, c));
            Console.WriteLine("{0} took {1} ticks.", "KnightProbability", res.TimeSpan.Ticks);
            #endregion //RepeatedStringMatch

            #region MaxSumOfThreeSubarrays
            #endregion //RepeatedStringMatch
        }

        #region RepeatedStringMatch
        public int RepeatedStringMatch(string A, string B)
        {
            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B))
            {
                return -1;
            }

            var res = 1;
            if (A.IndexOf(B) != -1)
            {
                return res;
            }

            var sb = new StringBuilder(A);
            if (A.Length < B.Length)
            {
                while (sb.Length < B.Length)
                {
                    sb.Append(A);
                    res++;
                }
            }
            else if (A.Length > B.Length)
            {
                sb.Append(A);
                res++;
            }

            var idx = sb.ToString().IndexOf(B);
            if (idx == -1 && sb.Length == B.Length)
            {
                sb.Append(A);
                res++;
                idx = sb.ToString().IndexOf(B);
            }

            if (idx !=  -1)
            {
                return res;
            }

            return -1;
        }
        #endregion //RepeatedStringMatch

        #region LongestUnivaluePath
        public int LongestUnivaluePath(TreeNode root)
        {
            int maxLength = int.MinValue;
            if (root == null)
            {
                return 0;
            }
            LongestUnivaluePathRecurse(root, ref maxLength);
            return maxLength;
        }

        public int LongestUnivaluePathRecurse(TreeNode node, ref int maxLength)
        {
            var leftLen = 0;
            var rightLen = 0;
            if (node.left != null)
            {
                leftLen = LongestUnivaluePathRecurse(node.left, ref maxLength);

                if (node.left.val == node.val)
                {
                    leftLen++;
                }
                else
                {
                    leftLen = 0;
                }
            }
            if (node.right != null)
            {
                rightLen = LongestUnivaluePathRecurse(node.right, ref maxLength);
                if (node.right.val == node.val)
                {
                    rightLen++;
                }
                else
                {
                    rightLen = 0;
                }
            }
            maxLength = Math.Max(maxLength, leftLen+rightLen);
            return Math.Max(leftLen, rightLen);
        }
        #endregion //LongestUnivaluePath

        #region KnightProbability
        public double KnightProbability(int N, int K, int r, int c)
        {
            throw new NotImplementedException();
        }
        #endregion //KnightProbability

        #region MaxSumOfThreeSubarrays
        public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
        {
            throw new NotImplementedException();
        }
        #endregion //MaxSumOfThreeSubarrays
    }
}
