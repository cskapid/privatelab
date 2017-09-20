using System;
using System.Diagnostics;

namespace TestPad
{
    public static class Utility
    {
        public static void Write<T>(T value)
        {
            Console.Write(value);
            Debug.Write(value);
        }

        public static void Write(string format, params object[] args)
        {
            var msg = string.Format(format, args);
            Console.Write(msg);
            Debug.Write(msg);
        }

        public static void WriteLine<T>(T value)
        {
            Console.WriteLine(value);
            Debug.WriteLine(value);
        }

        public static void WriteLine(string format, params object[] args)
        {
            var msg = string.Format(format, args);
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        public static void Fill<T>(this T[] array, T element)
        {
            if (array != null && array.Length > 0)
            {
                for(var i=0;i<array.Length;i++)
                {
                    array[i] = element;
                }
            }
        }

        public static void Fill<T>(this T[,] array, int dim, T element)
        {
            if (array != null && array.Length > 0)
            {
                for (var i = array.GetLowerBound(dim+1); i <= array.GetUpperBound(dim + 1); i++)
                {
                    array[dim, i] = element;
                }
            }
        }
    }
}
