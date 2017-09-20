using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class Contest49
    {
        public void ContestValidator()
        {
            #region CutOffTree
            var forest = new List<List<int>>
            {
                //new List<int> { 1, 2, 0 },
                //new List<int> { 0, 3, 4 },
                //new List<int> { 7, 5, 6 }
                new List<int> { 1, 2, 3, 0 },
                new List<int> { 0, 5, 4, 0 },
                new List<int> { 7, 6, 8, 9 }
            };
            var res = Timer.TimedFunc(() => this.CutOffTree(forest));
            Console.WriteLine("{0} took {1} ticks.", "CutOffTree", res.TimeSpan.Ticks);
            //res.Result.ForEach(Console.WriteLine);
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
    }
}
