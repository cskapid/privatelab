using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Contests
{
    public class Contest51
    {
        public void ContestValidator()
        {
            #region CalPoints
            //var ops = new string[] {
            //    //"5","2","C","D","+"
            //    "5","-2","4","C","D","9","+","+"
            //};
            //var res = Timer.TimedFunc(() => this.CalPoints(ops));
            //Console.WriteLine("{0} took {1} ticks.", "CalPoints", res.TimeSpan.Ticks);
            #endregion //CalPoints

            #region NextClosestTime
            ////var time = "19:34";
            //var time = "23:59";
            //var res = Timer.TimedFunc(() => this.NextClosestTime(time));
            //Console.WriteLine("{0} took {1} ticks.", "NextClosestTime", res.TimeSpan.Ticks);
            #endregion //NextClosestTime

            #region FindRedundantConnection
            //var input = new List<int[,]>
            //{
            //    new int[,] { { 1, 2 }, { 1, 3 }, { 2, 3 } },
            //    new int[,] { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 1, 4 }, { 1, 5 } },
            //    new int[,] { { 1, 3 }, { 3, 4 }, { 1, 5 }, { 3, 5 }, { 2, 3 } },
            //    new int[,] { { 1, 4 }, { 3, 4 }, { 1, 3 }, { 1, 2 }, { 4, 5 } },
            //    new int[,] { { 2, 3 }, { 5, 2 }, { 1, 5 }, { 4, 2 }, { 4, 1 } },
            //    new int[,] {{3,7},{1,4},{2,8},{1,6},{7,9},{6,10},{1,7},{2,3},{8,9},{5,9}}
            //};
            //foreach (var edges in input)
            //{
            //    var res = Timer.TimedFunc(() => this.FindRedundantConnection(edges));
            //    Console.WriteLine("{0} took {1} ticks.", "FindRedundantConnection", res.TimeSpan.Ticks);
            //}
            #endregion //FindRedundantConnection       e

            #region KEmptySlots
            var flowers = new int[] { 1, 3, 2 };
            var k = 1;
            var res = Timer.TimedFunc(() => this.KEmptySlots(flowers, k));
            Console.WriteLine("{0} took {1} ticks.", "KEmptySlots", res.TimeSpan.Ticks);
            #endregion //KEmptySlots
        }
        #region CalPoints
        public int CalPoints(string[] ops)
        {
            if (ops == null || ops.Length == 0)
            {
                return 0;
            }

            int[] nums = new int[ops.Length];
            for (int i = 0; i < ops.Length; i++)
            {
                nums[i] = int.MinValue;
            }

            int sum = 0;
            for (int i = 0; i < ops.Length; i++)
            {
                switch (ops[i])
                {
                    case "D":
                        if (i > 0)
                        {
                            int j = i - 1;
                            for (; j >= 0; j--)
                            {
                                if (nums[j] != int.MinValue)
                                {
                                    break;
                                }
                            }
                            nums[i] = 2 * nums[j];
                            sum += nums[i];
                        }
                        break;
                    case "C":
                        if (i > 0)
                        {
                            int j = i - 1;
                            for (; j >= 0; j--)
                            {
                                if (nums[j] != int.MinValue)
                                {
                                    break;
                                }
                            }
                            sum -= nums[j];
                            nums[j] = int.MinValue;
                        }
                        break;
                    case "+":
                        if (i > 1)
                        {
                            var num = 0;
                            var cnt = 2;
                            int j = i - 1;
                            for (; j >= 0 && cnt > 0; j--)
                            {
                                if (nums[j] != int.MinValue)
                                {
                                    num += nums[j];
                                    cnt--;
                                }
                            }
                            nums[i] = num;
                            sum += nums[i];
                        }
                        break;
                    default:
                        nums[i] = int.Parse(ops[i]);
                        sum += nums[i];
                        break;
                }
            }
            return sum;
        }
        #endregion //CalPoints

        #region NextClosestTime
        public string NextClosestTime(string time)
        {
            var digits = time.ToCharArray().Distinct().ToArray();
            while (true)
            {
                time = DateTime.Parse(time).AddMinutes(1).ToString("HH:mm");
                var curSet = time.ToCharArray().Distinct().ToArray();
                if (curSet.Except(digits).Count() == 0)
                {
                    return time;
                }
            }

            /*
            var arr = time.Remove(2,1).ToCharArray().Distinct().ToArray();
            var size = arr.Length;
            if (size == 1)
            {
                return time;
            }
            int minutes = int.Parse(time.Substring(0, 2)) * 60 + int.Parse(time.Substring(3));
            int diffFromMidnight = 1440 - minutes;

            var diff = int.MaxValue;
            var set = new HashSet<string>();
            var ans = string.Empty;
            var length = 4;
            int[] pos = new int[size];

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                sb.Append(arr[0]);
            }

            while (true)
            {
                var closest = sb.ToString();
                if (!set.Contains(closest))
                {
                    // output the current combination:
                    set.Add(closest);
                    int curMinutes = int.Parse(closest.Substring(0, 2)) * 60 + int.Parse(closest.Substring(2));
                    var curDiff = curMinutes - minutes;
                    if (curMinutes < minutes)
                    {
                        curDiff = curMinutes + diffFromMidnight;
                    }
                    if (diff > curDiff)
                    {
                        diff = curDiff;
                        ans = closest;
                    }
                }

                // move on to the next combination:
                int place = length - 1;
                while (place >= 0)
                {
                    if (++pos[place] == arr.Length)
                    {
                        // overflow, reset to zero
                        pos[place] = 0;
                        sb[place] = arr[0];
                        place--; // and carry across to the next value
                    }
                    else
                    {
                        // no overflow, just set the char value and we're done
                        sb[place] = arr[pos[place]];
                        break;
                    }
                }
                if (place < 0)
                    break;  // overflowed the last position, no more combinations
            }


            return ans;
            */
        }
        #endregion //NextClosestTime

        #region FindRedundantConnection
        public int[] FindRedundantConnection(int[,] edges)
        {
            int[] parent = new int[2001];
            for(int i=0;i<parent.Length;i++)
            {
                parent[i] = i;
            }

            for(int i=0;i<=edges.GetUpperBound(0);i++)
            {
                var f = edges[i, 0];
                var t = edges[i, 1];
                if (Find(parent, f) == Find(parent, t))
                {
                    return new int[] { f, t };
                }
                else
                {
                    parent[Find(parent, f)] = Find(parent, t);
                }
            }

            return new int[2];
        }

        private int Find(int[] parent, int f)
        {
            if (f != parent[f])
            {
                parent[f] = Find(parent, parent[f]);
            }

            return parent[f];
        }
        /*
        public int[] FindRedundantConnection(int[,] edges)
        {
            int[] ans = null;
            if (edges.Length == 0)
            {
                return ans;
            }

            var dict1 = new Dictionary<int, HashSet<int>>();
            var rowLen = edges.GetUpperBound(0)+1;
            for(int i=0;i<rowLen;i++)
            {
                var src = edges[i, 0];
                var dst = edges[i, 1];

                // Check and add current src/dst
                if (!MapNodes(dict1, src, dst) || !MapNodes(dict1, dst, src))
                {
                    ans = new int[2] { src, dst };
                }
                if (ans != null)
                {
                    return ans;
                }
                // Check if there are any indirect path available
                // Check if the dstination has option to go else where, 
                // if yes, src must also be able to go there
                if (dict1.ContainsKey(dst))
                {
                    foreach (var newDst in dict1[dst])
                    {
                        if (src == newDst)
                        {
                            continue;
                        }
                        if (!MapNodes(dict1, src, newDst) || !MapNodes(dict1, newDst, src))
                        {
                            ans = new int[2] { src, dst };
                        }

                    }
                }

                foreach (var newSrc in dict1[src])
                {
                    if (dst == newSrc)
                    {
                        continue;
                    }
                    if (!MapNodes(dict1, dst, newSrc) || !MapNodes(dict1, newSrc, dst))
                    {
                        ans = new int[2] { src, dst };
                    }
                }
           }

            return ans;
        }

        private bool MapNodes(Dictionary<int, HashSet<int>> dict1, int src, int dst)
        {
            if (!dict1.ContainsKey(src))
            {
                dict1[src] = new HashSet<int>();
            }
            if (!dict1[src].Contains(dst))
            {
                dict1[src].Add(dst);
            }
            else
            {
                return false;
            }
            return true;
        }
        */
        #endregion //FindRedundantConnection

        #region KEmptySlots
        public int KEmptySlots(int[] flowers, int k)
        {
            int[] days = new int[flowers.Length];

            for(int i=0;i<flowers.Length;i++)
            {
                days[flowers[i] - 1] = i + 1;
            }
            int left = 0, right = k + 1, res = int.MaxValue;
            for(int i=0; right < days.Length;i++)
            {
                if (days[i] < days[left] || days[i] <= days[right])
                {
                    if (i == right)
                    {
                        res = Math.Min(res, Math.Max(days[left], days[right]));
                    }
                    left = i;
                    right = k + 1 + i;
                }
            }
            return res == int.MaxValue ? -1 : res;
        }
        #endregion //KEmptySlots
    }
}