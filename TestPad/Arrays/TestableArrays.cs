using System;
using System.Collections.Generic;

namespace TestPad.Arrays
{
    public static class TestableArrays
    {
        public static IList<int[]> BuildTestArrays()
        {
            var arrays = new List<int[]> {
                new int[] { },
                new int[] { 5 },
                new int[] { 1, 2, 3, 4, 5},
                new int[] { 4, 1, 1, 1, 2, 2, 2, 4, 4, 4, 4, 4, 4, 4, 1, 2, 2, 4, 4},
                new int[] { 1, 2, 2, 2, 2, 4, 4, 4, 2},
                new int[] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1},
            };
            return arrays;
        }

        public static List<Tuple<int, int>>[] BuildIntervals()
        {
            return new List<Tuple<int, int>>[] {
                new List<Tuple<int, int>> {  },
                new List<Tuple<int, int>> { new Tuple<int, int>(1, 5) },
                new List<Tuple<int, int>> { new Tuple<int, int>(1, 5), new Tuple<int, int>(6, 10) },
                new List<Tuple<int, int>> { new Tuple<int, int>(1, 3), new Tuple<int, int>(2, 4) },
                new List<Tuple<int, int>> { new Tuple<int, int>(1, 5), new Tuple<int, int>(2, 4), new Tuple<int, int>(5, 8) },
                new List<Tuple<int, int>> { new Tuple<int, int>(3, 7), new Tuple<int, int>(1, 7), new Tuple<int, int>(2, 4), new Tuple<int, int>(5, 7), new Tuple<int, int>(8, 10) }
            };
        }
    }
}
