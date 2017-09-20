namespace TestPad.Matrix
{
    public class MatrixBuilder
    {
        public int[,] BuildMatrix(int rows, int cols, int[] elements)
        {
            int[,] matrix = new int[rows, cols];
            var crow = 0;
            var ccol = 0;
            var index = (crow * rows) + ccol;
            while (index < elements.Length)
            {
                matrix[crow, ccol] = elements[index];
                if (++ccol == cols)
                {
                    ccol = 0;
                    if (++crow == rows)
                    {
                        break;
                    }
                }
                index = (crow * rows) + ccol;
            }
            return matrix;
        }
    }
}
