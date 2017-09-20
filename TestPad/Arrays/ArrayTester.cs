namespace TestPad.Arrays
{
    public static class ArrayTester
    {
        public static void RunTests()
        {
            var exercises = new Exercises();
            Utility.WriteLine(exercises.FindLHS(new int[] { 1, 3, 1 }));
            Utility.WriteLine(exercises.FindLHS(new int[] { 1, 1, 1 }));
            Utility.WriteLine(exercises.FindLHS(new int[] { 1, 3, 2, 2, 5, 2, 3, 7 }));
            Utility.WriteLine(exercises.FindLHS(new int[] { 1, 3, 2, 2, 4, 2, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8}));
            /*
            //var k = 2;
            //var nums = new int[] { 1, 1, 1 };
            var k = 100;
            var nums = new int[] { 28, 54, 7, -70, 22, 65, -6 };
            foreach (var num in nums)
            {
                Utility.Write("{0} ", num);
            }
            Utility.WriteLine(string.Empty);
            Utility.WriteLine("Expected sum {0}", k);
            var tot = exercises.SubarraySum(nums, k);
            Utility.WriteLine("Total possible arrays are {0}", tot);
            */
            /*
            var nums = new int[] { 7, 2, 3, 1, 5, 8, 9, 6 };
            Utility.Write("Input array ");
            foreach(var n in nums)
            {
                Utility.Write("{0} ", n);
            }
            Utility.WriteLine(string.Empty);
            var max = exercises.MaximalLengthOfIncrementalSubsequence(nums);
            Utility.WriteLine("Max length is {0}", max);
            */
            /*
            foreach (var array in TestableArrays.BuildTestArrays())
            {
                try
                {
                    var element = exercises.MajorityElement(array);
                    Utility.WriteLine(element);
                }
                catch(Exception e)
                {
                    Utility.WriteLine(e.Message);
                }
            }
            */

            //foreach(var intervals in TestableArrays.BuildIntervals())
            //{
            //    if (intervals != null)
            //    {
            //        exercises.PrintIntervals(intervals);
            //        var res{}ult = exercises.MergeOverlappingIntervals(intervals);
            //        exercises.PrintIntervals(result);
            //    }
            //}

            /*
            var arr = new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 };
            arr = new int[] { 3, 3, 7, 7, 10, 11, 11 };
            arr = new int[] { 1, 1, 2 };
            foreach (var item in arr)
            {
                Utility.Write("{0} ", item);
            }
            Utility.WriteLine(string.Empty);
            var unique = exercises.SingleNonDuplicate(arr);
            Utility.WriteLine("Unique element is {0}", unique);
            //Utility.WriteLine("Score: {0}", exercises.RemoveBoxes(new int[] { }));
            //Utility.WriteLine("Score: {0}", exercises.RemoveBoxes(new int[] { 1 }));
            //Utility.WriteLine("Score: {0}", exercises.RemoveBoxes(new int[] { 1, 2 }));
            //Utility.WriteLine("Score: {0}", exercises.RemoveBoxes(new int[] { 1, 1, 1 }));
            //Utility.WriteLine("Score: {0}", exercises.RemoveBoxes(new int[] { 1, 2, 1 }));
            //Utility.WriteLine("Score: {0}", exercises.RemoveBoxes(new int[] { 1, 2, 1, 2 }));
            //Utility.WriteLine("Score: {0}", exercises.RemoveBoxes(new int[] { 2, 2, 1, 1, 1, 2, 2 }));
            //Utility.WriteLine("Score: {0}", exercises.RemoveBoxes(new int[] { 1, 3, 2, 2, 2, 3, 4, 3, 1 }));
            */
        }
    }
}
