using System;
using System.Text;

namespace Solution.Contests
{
    public class Contest52
    {
        public void ContestValidator()
        {
            #region RepeatedStringMatch
            var A = "abcd";
            var B = "cdabcdab";
            var res = Timer.TimedFunc(() => this.RepeatedStringMatch(A, B));
            Console.WriteLine("{0} took {1} ticks.", "RepeatedStringMatch", res.TimeSpan.Ticks);
            #endregion //RepeatedStringMatch

            #region LongestUnivaluePath
            #endregion //RepeatedStringMatch

            #region KnightProbability
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
            var sb = new StringBuilder(A);
            while(sb.Length < B.Length)
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
            throw new NotImplementedException();
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
