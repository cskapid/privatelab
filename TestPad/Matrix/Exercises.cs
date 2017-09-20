using System;
using System.Collections.Generic;
using System.Linq;

namespace TestPad.Matrix
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var pt = (Point) obj;
            return (pt.X == this.X && pt.Y == this.Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Point pt1, Point pt2)
        {
            if (pt1 == null || pt2 == null)
            {
                return false;
            }

            return (pt1.X == pt2.X && pt1.Y == pt2.Y);
        }

        public static bool operator !=(Point pt1, Point pt2)
        {
            return !(pt1 == pt2);
        }
    }

    public class Exercises
    {
        private struct PointMetaData
        {
            public bool Visited { get; set; }
            public int Distance { get; set; }

            public PointMetaData(bool visited, int distance)
            {
                this.Distance = distance;
                this.Visited = visited;
            }
        }
        /*
        public int LongestLine(int[,] M)
        {
            if (M == null || M.Length == 0)
            {
                return 0;
            }

            var maxLen = 0;
            var neighbours = new Dictionary<int, int> { {0, 1 }, {0, -1}, {1, 0 }, { -1, 0}, { 1, 1 }, { -1, -1 } };
            var visited = new int[(M.GetUpperBound(0)+1) * (M.GetUpperBound(1)+1)];
            for(var i=0;i<=M.GetUpperBound(0);i++)
            {
                for(var j=0;j<=M.GetUpperBound(1);j++)
                {
                    if (M[i,j] == 0)
                    {
                        continue;
                    }
                    
                    foreach(var n in neighbours)
                    {
                        var len = 1 + FindLength(M, n.Key, n.Value);
                        if (len > maxLen)
                        {
                            maxLen = len;
                        }
                    }
                }
            }

            return maxLen;
        }

        public int FindLength(int[,] M, int x, int y)
        {
            return 0;
        }
        */
        public int ShortestDistanceBetweenPoints(int[,] matrix, Point start, Point end, int blocker)
        {
            if (matrix == null || matrix.Length == 0 || start == end)
            {
                return 0;
            }

            var rows = matrix.GetUpperBound(0) + 1;
            var cols = matrix.GetUpperBound(1) + 1;
            if (start.X < 0 || start.X >= rows || start.Y < 0 || start.Y >= cols || matrix[start.X, start.Y] == blocker)
            {
                Utility.WriteLine("Invalid start point @ ({0}, {1})", start.X, start.Y);
                return 0;
            }
            if (end.X < 0 || end.X >= rows || end.Y < 0 || end.Y >= cols || matrix[end.X, end.Y] == blocker)
            {
                Utility.WriteLine("Invalid end point @ ({0}, {1})", end.X, end.Y);
                return 0;
            }

            var queue = new Queue<Point>();
            var metadata = new PointMetaData[rows,cols];
            queue.Enqueue(start);
            metadata[start.X, start.Y].Distance = 0;
            metadata[start.X, start.Y].Visited = true;

            while (queue.Count > 0)
            {
                var pt = queue.Dequeue();
                var newdist = metadata[pt.X, pt.Y].Distance + 1;

                VisitElement(() => pt.X > 0, pt.X - 1, pt.Y, blocker, newdist, matrix, metadata, queue);
                VisitElement(() => pt.X < rows - 1, pt.X + 1, pt.Y, blocker, newdist, matrix, metadata, queue);
                VisitElement(() => pt.Y > 0, pt.X, pt.Y -1, blocker, newdist, matrix, metadata, queue);
                VisitElement(() => pt.Y < cols - 1, pt.X, pt.Y + 1, blocker, newdist, matrix, metadata, queue);
            }


            return metadata[end.X, end.Y].Distance;
        }

        private void VisitElement(Func<bool> func, int x, int y, int blocker, int newdist, int[,] matrix, PointMetaData[,] metadata, Queue<Point> queue)
        {
            if (func() && matrix[x, y] != blocker && (!metadata[x, y].Visited || metadata[x, y].Distance > newdist))
            {
                if (!metadata[x, y].Visited)
                {
                    queue.Enqueue(new Point(x, y));
                }
                metadata[x, y].Visited = true;
                metadata[x, y].Distance = newdist;
            }
        }


        public int MeetingPointDistance(/*int[,] matrix*/)
        {
            var matrix = new int[,] {
                { 1, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0 } };

            var m = matrix.GetUpperBound(0) + 1;
            var n = matrix.GetUpperBound(1) + 1;

            var I = new int[m];
            var J = new int[n];

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        ++I[i];
                        ++J[j];
                    }
                }
            }
            int total = 0;
            var t = new int[][] { I, J };
            foreach (var k in t)
            {
                var i = 0;
                var j = k.Length - 1;
                while (i < j)
                {
                    var x = System.Math.Min(k[i], k[j]);
                    total += x * (j - i);
                    if ((k[i] -= x) == 0) ++i;
                    if ((k[j] -= x) == 0) --j;
                }
            }
            return total;
            /*
            int total = 0;
            var Z = new int[m * n];
            for(var dim = 0;dim<2;dim++)
            {
                var i = 0;
                var j = 0;
                if (dim == 0)
                {
                    for(var x = 0; x < n; x++)
                    {
                        for(var y=0; y < m; y++)
                        {
                            if (matrix[y, x] == 1)
                            {
                                Z[j++] = x;
                            }
                        }
                    }
                }
                else
                {
                    for (var x = 0; x < m; x++)
                    {
                        for (var y = 0; y < n; y++)
                        {
                            if (matrix[x, y] == 1)
                            {
                                Z[j++] = x;
                            }
                        }
                    }
                }

                while (i < --j)
                {
                    total += Z[j] - Z[i++];
                }
            }

            return total;
            */
            /*
            var I = new List<int>(m);
            var J = new List<int>(n);

            for(var i=0;i<m;i++)
            {
                for(var j=0;j<n;j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        I.Add(i);
                        J.Add(j);
                    }
                }
            }

            return GetMin(I) + GetMin(J);
            */
        }

        public int GetMin(List<int> list)
        {
            int ret = 0;

            list.Sort();
            int i = 0;
            int j = list.Count - 1;
            while (i < j)
            {
                ret += list[j--] - list[i++];
            }

            return ret;
        }

        /*
        public int DistanceBetweenPoints(int x1, int y1, int x2, int y2)
        {
            return System.Math.Abs(x1 - x2) + System.Math.Abs(y1 - y2);
        }
        */

        public int MaxVacationDays(int[,] flights, int[,] days)
        {
            int cities = flights.GetLength(0);
            int weeks = days.GetLength(1);

            int[] dp = new int[cities];
            Utility.Fill(dp, int.MinValue);
            dp[0] = 0;
            for (int i = 0; i < weeks; i++)
            {

                int[] temp = new int[cities];
                Utility.Fill(temp, int.MinValue);
                for (int j = 0; j < cities; j++)
                {
                    for (int k = 0; k < cities; k++)
                    {
                        if (j == k || flights[k, j] == 1)
                        {
                            temp[j] = System.Math.Max(temp[j], dp[k] + days[j, i]);
                        }
                    }
                }
                dp = temp;
            }

            return dp.Max();
            /*
            if (flights == null || flights.Length == 0 || days == null || days.Length == 0)
            {
                return;// 0;
            }

            var startCity = 0;
            var cityCount = flights.GetLength(0);
            var weekCount = days.GetLength(0);

            int?[,] vacationChart = new int?[weekCount, cityCount];
            for(int i=0;i<cityCount;i++)
            {
                vacationChart[0, i] = 0;
            }
            BuildWeeklyVacation(flights, days, cityCount, startCity, 0, ref vacationChart);

            for (int week = 1; week < weekCount; week++)
            {
                for (int i = 0; i < cityCount; i++)
                {
                    if (vacationChart[week, i].HasValue)
                    {
                        BuildWeeklyVacation(flights, days, cityCount, i, week, ref vacationChart);
                    }
                }
            }

            //return weeklyVacation.Max().GetValueOrDefault();
            */
        }

        private void BuildWeeklyVacation(int[,] flights, int[,] days, int cityCount, int startCity, int week, ref int?[,] vacationChart)
        {
            for (int city = 0; city < cityCount; city++)
            {
                if (city == startCity)
                {
                    vacationChart[week + 1, city] = vacationChart[week, city] + days[city, week];
                }
                else if (flights[startCity, city] == 1)
                {
                    vacationChart[week + 1, city] = vacationChart[week, city] + days[city, week];
                }
            }
        }

        public int[,] MatrixReshape(int[,] nums, int r, int c)
        {
            var tot = r * c;
            if (nums == null || nums.Length == 0 || tot != nums.Length)
            {
                return nums;
            }

            int[,] result = new int[r, c];
            int /*nr = 0,*/ nc = 0;
            for (var i = 0; i <= nums.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= nums.GetUpperBound(1); j++)
                {
                    result[nc / c, nc % c] = nums[i, j];
                    nc++;
                    //nc = ++nc % c;
                    //if (nc == 0)
                    //{
                    //    nr++;
                    //}
                }
            }

            return result;
        }

        public int FindPaths(int m, int n, int N, int i, int j)
        {
            // TODO
            return 0;
        }

        //[‎5/‎9/‎2017 9:02 AM] Jitendra Kumar: 
        //5 7 [2,2]
        //[4,4]
        //[[3,0], [2,5]] Expected 12

        public int MinDistance(int height, int width, int[] tree, int[] squirrel, int[][] nuts)
        {
            if ((height == 0 && width == 0) || tree == null || tree.Length != 2 || squirrel == null || squirrel.Length != 2 || nuts == null || nuts.Length == 0)
            {
                return 0;
            }

            // Find the total distance between tree and nuts
            int distToTreeFromNuts = 0;
            int d = 0;
            foreach(var nut in nuts)
            {
                int distanceToTree = System.Math.Abs(tree[0] - nut[0]) + System.Math.Abs(tree[1] - nut[1]);
                int distanceToSquirrel = System.Math.Abs(squirrel[0] - nut[0]) + System.Math.Abs(squirrel[1] - nut[1]);
                distToTreeFromNuts += (distanceToTree * 2);
                d = System.Math.Max(d, distanceToTree - distanceToSquirrel);
            }

            return distToTreeFromNuts - d;
        }
    }
}
