using System.Collections.Generic;

namespace TestPad.Matrix
{
    public class MatrixPrinter
    {
        public void PrintMatrix(int[,] matrix)
        {
            if (matrix.Length == 0)
            {
                return;
            }

            var rows = matrix.GetUpperBound(0)+1;
            var cols = matrix.GetUpperBound(1)+1;
            Utility.WriteLine("Printing an ({0}, {1}) matrix...", rows, cols);
            var index = 0;
            while(index < matrix.Length)
            {
                Utility.Write("{0}{1}", matrix[index / cols, index % cols], index % cols == cols-1 ? string.Empty : " ");
                if (++index % cols == 0)
                {
                    Utility.WriteLine(string.Empty);
                }
            }
        }

        public IList<int> SpiralOrder(int[,] matrix)
        {
            if (matrix.Length == 0)
            {
                return new List<int>(0);
            }


            int bRow = 0;
            int eRow = matrix.GetUpperBound(0);
            int bCol = 0;
            int eCol = matrix.GetUpperBound(1);
            var list = new List<int>((eRow + 1) * (eCol + 1));
            int direction = 0;
            var i = bRow;
            var j = bCol;
            while (list.Count < list.Capacity)
            {
                list.Add(matrix[i, j]);
                if (list.Count == list.Capacity)
                {
                    break;
                }
                if (direction == 0)
                {
                    if (j+1 > eCol)
                    {
                        direction = 1;
                        bRow++;
                        i++;
                        continue;
                    }
                    j++;
                }
                else if (direction == 1)
                {
                    if (i + 1 > eRow)
                    {
                        direction = 2;
                        eCol--;
                        j--;
                        continue;
                    }
                    i++;
                }
                else if (direction == 2)
                {
                    if (j - 1 < bCol)
                    {
                        direction = 3;
                        eRow--;
                        i--;
                        continue;
                    }
                    j--;
                }
                else if (direction == 3)
                {
                    if (i - 1 < bRow)
                    {
                        direction = 0;
                        bCol++;
                        j++;
                        continue;
                    }
                    i--;
                }
                /*
                for (int i = bCol; i <= eCol; i++)
                {
                    list.Add(matrix[bRow, i]);
                }
                bRow++;

                for (int i = bRow; i <= eRow; i++)
                {
                    list.Add(matrix[i, eCol]);
                }
                eCol--;

                if (bRow <= eRow)
                {
                    for (int i = eCol; i >= bCol; i--)
                    {
                        list.Add(matrix[eRow, i]);
                    }
                }
                eRow--;

                if (bCol <= eCol)
                {
                    for (int i = eRow; i >= bRow; i--)
                    {
                        list.Add(matrix[i, bCol]);
                    }
                }
                bCol++;
                */
            }

            return list;
        }

        public IList<int> SpiralOrderInLoops(int[,] matrix)
        {
            if (matrix.Length == 0)
            {
                return new List<int>(0);
            }


            int bRow = 0;
            int eRow = matrix.GetUpperBound(0);
            int bCol = 0;
            int eCol = matrix.GetUpperBound(1);
            var list = new List<int>((eRow + 1) * (eCol + 1));
            while (list.Count < list.Capacity)
            {
                for (int i = bCol; i <= eCol; i++)
                {
                    list.Add(matrix[bRow, i]);
                }
                bRow++;

                for (int i = bRow; i <= eRow; i++)
                {
                    list.Add(matrix[i, eCol]);
                }
                eCol--;

                if (bRow <= eRow)
                {
                    for (int i = eCol; i >= bCol; i--)
                    {
                        list.Add(matrix[eRow, i]);
                    }
                }
                eRow--;

                if (bCol <= eCol)
                {
                    for (int i = eRow; i >= bRow; i--)
                    {
                        list.Add(matrix[i, bCol]);
                    }
                }
                bCol++;
            }

            return list;
        }
        /*
    public int PaintHousesWithMinimumCost(int[,] matrix)
    {
        if (matrix.Length == 0)
        {
            return 0;
        }

        var cost = 0;

    }
    */
    }
}
