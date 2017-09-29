using System;
using System.Collections.Generic;

namespace Solution.Contests
{
    public class Contest49
    {
        public void ContestValidator()
        {
            #region FindNumberOfLIS
            var nums = new int[] {
                1,3,5,4,7
                //2,2,2,2,2
            };
            var res = Timer.TimedFunc(() => this.FindNumberOfLIS(nums));
            Console.WriteLine("{0} took {1} ticks.", "FindNumberOfLIS", res.TimeSpan.Ticks);
            #endregion //FindLengthOfLCIS

            #region FindLengthOfLCIS
            //var nums = new int[] {
            //    //1,3,5,4,7
            //    2,2,2,2,2
            //};
            //var res = Timer.TimedFunc(() => this.FindLengthOfLCIS(nums));
            //Console.WriteLine("{0} took {1} ticks.", "FindLengthOfLCIS", res.TimeSpan.Ticks);
            #endregion //FindLengthOfLCIS

            #region MagicDirectory
            //MagicDictionary md = new MagicDictionary();
            //md.BuildDict(new string[] { "hello", "hallo", "Solution" });
            //var searchWords = new string[]
            //{
            //    "hello",
            //    "hhllo",
            //    "hell",
            //    "Solutiond"
            //};
            //foreach(var word in searchWords)
            //{
            //    Console.WriteLine("Input: {0}, SearchResult: {1}", word, md.Search(word));
            //}
            #endregion //MagicDirectory

            #region CutOffTree
            //var forest = new List<List<int>>
            //{
            //    //new List<int> { 1, 2, 0 },
            //    //new List<int> { 0, 3, 4 },
            //    //new List<int> { 7, 5, 6 }
            //    new List<int> { 1, 2, 3, 0 },
            //    new List<int> { 0, 5, 4, 0 },
            //    new List<int> { 7, 6, 8, 9 }
            //};
            //var res = Timer.TimedFunc(() => this.CutOffTree(forest));
            //Console.WriteLine("{0} took {1} ticks.", "CutOffTree", res.TimeSpan.Ticks);
            ////res.Result.ForEach(Console.WriteLine);
            #endregion //CutOffTree
        }
        #region CutOffTree
        public int CutOffTree(List<List<int>> forest)
        {
            int[][] dir = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

            if (forest == null || forest.Count == 0)
            {
                return 0;
            }
            var r = forest.Count;
            var c = forest[0].Count;
            var size = r * c;
            var visited = new bool[size];
            int steps = -1;
            if (forest[0][0] == 0)
            {
                return -1;
            }
            int i = 0;
            int j = 0;
            while(true)
            {
                steps++;
                forest[i][j] = 1;
                var vIndex = (i * c) + j;
                visited[vIndex] = true;

                var val = int.MaxValue;
                var tIndex = -1;
                for (int d = 0;d<4;d++)
                {
                    var ti = i + dir[d][0];
                    var tj = j + dir[d][1];
                    vIndex = (ti * c) + tj;
                    if (ti < r && !visited[vIndex] && forest[ti][tj] != 0)
                    {
                        if (forest[ti][tj] < val)
                        {
                            val = forest[ti][tj];
                            tIndex = vIndex;
                        }
                    }
                }

                if (tIndex == -1)
                {
                    break;
                }
                i = tIndex / c;
                j = tIndex % c;
            }
            return steps;
        }
        #endregion //CutOffTree

        public int FindNumberOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int size = nums.Length;
            int maxLen = 1;
            int cnt = 0;
            int[] len = new int[size];
            for (int i = 0; i < size; i++)
                len[i] = 1;
            int[] lenCnt = new int[size];
            for (int i = 0; i < size; i++)
                lenCnt[i] = 1;
            for (int i=1;i<size;i++)
            {
                for(int j=0;j<i;j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (len[j]+1 > len[i])
                        {
                            len[i] = len[j] + 1;
                            lenCnt[i] = lenCnt[j];
                        }
                        else if (len[j]+1 == len[i])
                        {
                            lenCnt[i] += lenCnt[j];
                        }
                    }
                }
                maxLen = Math.Max(maxLen, len[i]);
            }

            for(int i=0;i<size;i++)
            {
                if (len[i] == maxLen)
                {
                    cnt += lenCnt[i];
                }
            }
            return cnt;
            /*
            List<List<int>>[] listOfSequence = new List<List<int>>[nums.Length];
            int i, j;

            for (i = 0; i < nums.Length; i++)
            {
                listOfSequence[i] = new List<List<int>> { new List<int> { nums[i] } };
            }

            int cnt = 1;
            int maxLen = 1;
            for (i = 1; i < nums.Length; i++)
            {
                bool yes = true;
                int curMaxLen = 1;
                for (j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        yes = false;
                        foreach(var list in listOfSequence[j])
                        {
                            if (list.Count + 1 < curMaxLen)
                            {
                                continue;
                            }
                            if (list.Count +1 > curMaxLen)
                            {
                                curMaxLen = list.Count + 1;
                                listOfSequence[i].Clear();
                            }
                            if (curMaxLen > maxLen)
                            {
                                cnt = 1;
                                maxLen = curMaxLen;
                            }
                            else if (curMaxLen == maxLen)
                            {
                                cnt++;
                            }
                            var curList = list.ConvertAll(x => x);
                            curList.Add(nums[i]);
                            listOfSequence[i].Add(curList);
                        }
                    }
                }
                if (yes)
                {
                    if (curMaxLen > maxLen)
                    {
                        cnt = 1;
                        maxLen = curMaxLen;
                    }
                    else if (curMaxLen == maxLen)
                    {
                        cnt++;
                    }
                }
            }

            return cnt;
            */
        }

        #region FindLengthOfLCIS
        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int maxLength = 1;
            int curLength = 1;
            for(int i=1;i<nums.Length;i++)
            {
                if (nums[i-1] < nums[i])
                {
                    curLength++;
                    continue;
                }
                maxLength = Math.Max(maxLength, curLength);
                curLength = 1;
            }

            return Math.Max(maxLength, curLength);
        }
        #endregion //FindLengthOfLCIS

        #region MagicDirectory
        private class MagicDictionary
        {
            private Dictionary<string, List<int[]>> directory = new Dictionary<string, List<int[]>>();

            //HashSet<string> directory = new HashSet<string>();
            //HashSet<string> matches = new HashSet<string>();
            //Dictionary<int, int> lengthCount = new Dictionary<int, int>();

            /** Initialize your data structure here. */
            public MagicDictionary()
            {

            }

            /** Build a dictionary through a list of words */
            public void BuildDict(string[] dict)
            {
                foreach(var word in dict)
                {
                    for(int i=0;i<word.Length;i++)
                    {
                        var key = word.Substring(0, i) + word.Substring(i + 1);
                        int[] pair = new int[] { i, word[i] };
                        List<int[]> val;
                        if (!directory.TryGetValue(key, out val))
                        {
                            val = new List<int[]>();
                        }
                        val.Add(pair);
                        directory[key] = val;
                    }
                }
            }

            /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
            public bool Search(string word)
            {
                for(int i=0;i<word.Length;i++)
                {
                    var key = word.Substring(0, i) + word.Substring(i + 1);
                    if (directory.ContainsKey(key))
                    {
                        foreach(var pair in directory[key])
                        {
                            if (pair[0] == i && pair[1] != word[i])
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
        }
        #endregion //MagicDirectory
    }
}
