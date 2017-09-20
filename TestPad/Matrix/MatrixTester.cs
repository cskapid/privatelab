namespace TestPad.Matrix
{
    public static class MatrixTester
    {
        public static void RunTests()
        {
            var exercises = new Exercises();
            var printer = new MatrixPrinter();
            var builder = new MatrixBuilder();

            //5 7 [2,2]
            //[4,4]
            //[[3,0], [2,5]] Expected 12
            exercises.MinDistance(5, 7, new int[] { 2, 2 }, new int[] { 4, 4 }, new int[][] { new int[] { 3, 0 }, new int[] { 2, 5} } );
            /*
            //var flights = new int[,] { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } };
            //var days = new int[,] { { 1, 3 }, { 6, 0 }, { 3, 3 } };
            var flights = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            var days = new int[,] { { 1, 1, 1 }, { 7, 7, 7 }, { 7, 7, 7 } };
            Utility.WriteLine("Max vacation days: {0}", exercises.MaxVacationDays(flights, days));
            */

            /*
            //var nums = new int[,] { { 1, 2 }, { 3, 4 } };
            //var nums = new int[,] { { 1, 2 }, { 3, 4 } };
            var nums = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            for (var i = 0; i <= nums.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= nums.GetUpperBound(1); j++)
                {
                    Utility.Write("{0} ", nums[i, j]);
                }
                Utility.WriteLine(string.Empty);
            }
            //var res = MatrixReshape(nums, 1, 4);
            //var res = MatrixReshape(nums, 2, 4);
            var res = exercises.MatrixReshape(nums, 3, 2);
            for (var i = 0; i <= res.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= res.GetUpperBound(1); j++)
                {
                    Utility.Write("{0} ", res[i, j]);
                }
                Utility.WriteLine(string.Empty);
            }
            */
            /*
            var matrices = TestableMatrices.BuildTestMatrix();
            printer.PrintMatrix(matrices[0]);
            Utility.WriteLine("Shortest distaince between (1, 0) and (0, 1) is {0}", exercises.ShortestDistanceBetweenPoints(matrices[0], new Point(1, 0), new Point(0, 1), 0));

            printer.PrintMatrix(matrices[1]);
            Utility.WriteLine("Shortest distaince between (0, 1) and (1, 2) is {0}", exercises.ShortestDistanceBetweenPoints(matrices[1], new Point(0, 1), new Point(1, 2), 0));

            printer.PrintMatrix(matrices[2]);
            Utility.WriteLine("Shortest distaince between (1, 0) and (2, 1) is {0}", exercises.ShortestDistanceBetweenPoints(matrices[2], new Point(1, 0), new Point(2, 1), 0));

            printer.PrintMatrix(matrices[3]);
            Utility.WriteLine("Shortest distaince between (0, 0) and (2, 2) is {0}", exercises.ShortestDistanceBetweenPoints(matrices[3], new Point(0, 0), new Point(2, 2), 0));

            printer.PrintMatrix(matrices[4]);
            Utility.WriteLine("Shortest distaince between (0, 0) and (3, 3) is {0}", exercises.ShortestDistanceBetweenPoints(matrices[4], new Point(0, 0), new Point(3, 3), 0));
            */
            /*
            var matrix = builder.BuildMatrix(3, 5, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            printer.PrintMatrix(matrix);
            var timer = new Timer();
            var result2 = timer.TimedFunc(() => { return printer.SpiralOrderInLoops(matrix); });
            var result1 = timer.TimedFunc(() => { return printer.SpiralOrder(matrix); });
            Utility.WriteLine(string.Empty);
            Utility.WriteLine("SpiralOrder took {0}ms", result1.Item1.TotalMilliseconds);
            foreach (var item in result1.Item2)
            {
                Utility.Write("{0} ", item);
            }
            Utility.WriteLine(string.Empty);
            Utility.WriteLine("SpiralOrderInLoops took {0}ms", result2.Item1.TotalMilliseconds);
            foreach (var item in result2.Item2)
            {
                Utility.Write("{0} ", item);
            }
            Utility.WriteLine(string.Empty);
            */
        }
    }
}