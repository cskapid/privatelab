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
            var time = "19.34";
            //var time = "23.59";
            var res = Timer.TimedFunc(() => this.NextClosestTime(time));
            Console.WriteLine("{0} took {1} ticks.", "NextClosestTime", res.TimeSpan.Ticks);
            #endregion //NextClosestTime

            #region FindRedundantConnection
            //var res = Timer.TimedFunc(() => this.FindRedundantConnection(null));
            //Console.WriteLine("{0} took {1} ticks.", "FindRedundantConnection", res.TimeSpan.Ticks);
            #endregion //FindRedundantConnection

            #region KEmptySlots
            //var res = Timer.TimedFunc(() => this.KEmptySlots(null, 0));
            //Console.WriteLine("{0} took {1} ticks.", "KEmptySlots", res.TimeSpan.Ticks);
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
            var arr = time.Remove(2,1).ToCharArray().Distinct().ToArray();
            var size = arr.Length;
            if (size == 1)
            {
                return time;
            }
            int minutes = int.Parse(time.Substring(0, 2)) * 60 + int.Parse(time.Substring(3));

            var diff = int.MaxValue;
            var maxCombinations = Math.Pow(size, 4);
            var set = new HashSet<string>();
            var ans = string.Empty;


            return ans;
        }
        #endregion //NextClosestTime

        #region FindRedundantConnection
        public int[] FindRedundantConnection(int[,] edges)
        {
            throw new NotImplementedException();
        }
        #endregion //FindRedundantConnection

        #region KEmptySlots
        public int KEmptySlots(int[] flowers, int k)
        {
            throw new NotImplementedException();
        }
        #endregion //KEmptySlots
    }
}
