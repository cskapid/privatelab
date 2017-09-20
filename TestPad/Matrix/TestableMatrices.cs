using System.Collections.Generic;

namespace TestPad.Matrix
{
    public static class TestableMatrices
    {
        public static IList<int[,]> BuildTestMatrix()
        {
            var builder = new MatrixBuilder();

            return new List<int[,]> {
                builder.BuildMatrix(2, 2, new int[] { 0, 1, 1, 0 }),
                builder.BuildMatrix(2, 3, new int[] { 0, 1, 1, 0, 1, 1 }),
                builder.BuildMatrix(3, 2, new int[] { 0, 1, 1, 0, 1, 1 }),
                builder.BuildMatrix(3, 4, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
                builder.BuildMatrix(4, 4, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }),
            };
        }
    }
}
