using System;
using System.Collections.Generic;

namespace Solution
{
    public class Problems
    {
        public void ContestValidator()
        {
            #region P125_IsPalindrome
            var list = new List<string> {
            };
            foreach (var s in list)
            {
                var res = Timer.TimedFunc(() => this.P125_IsPalindrome(s));
                Console.WriteLine("{0} took {1} ticks.", "P125_IsPalindrome", res.TimeSpan.Ticks);
                Console.WriteLine("Input: {0} --> Output:{1}", s, res.Result);
            }
            #endregion //P125_IsPalindrome
        }

        public int P300_LengthOfLIS(int[] nums)
        {
            throw new NotImplementedException();
        }

        public bool P125_IsPalindrome(string s)
        {
            throw new NotImplementedException();
        }

        public int P421_FindMaximumXOR(int[] nums)
        {
            throw new NotImplementedException();
        }

        public IList<string> P472_FindAllConcatenatedWordsInADict(string[] words)
        {
            throw new NotImplementedException();
        }

        public string P648_ReplaceWords(IList<string> dict, string sentence)
        {
            throw new NotImplementedException();
        }

        public IList<IList<int>> P336_PalindromePairs(string[] words)
        {
            throw new NotImplementedException();
        }

        public int P647_CountSubstrings(string s)
        {
            throw new NotImplementedException();
        }

        public bool P473_Makesquare(int[] nums)
        {
            throw new NotImplementedException();
        }

        public int P494_FindTargetSumWays(int[] nums, int S)
        {
            throw new NotImplementedException();
        }

        public int P576_FindPaths(int m, int n, int N, int i, int j)
        {
            throw new NotImplementedException();
        }

        private class P208_Trie
        {

            /** Initialize your data structure here. */
            public P208_Trie()
            {

            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {

            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                throw new NotImplementedException();
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                throw new NotImplementedException();
            }
        }
    }
}
