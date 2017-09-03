using System;
using System.Linq;

namespace SquaresInMatrix
{
    public class Launcher
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[0];
            char[][] matrix = new char[rowsCount][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            int count = 0;

            for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    char topLeft = matrix[rowIndex][colIndex];
                    char topRight = matrix[rowIndex][colIndex + 1];
                    char bottomLeft = matrix[rowIndex + 1][colIndex];
                    char bottomRight = matrix[rowIndex + 1][colIndex + 1];

                    if (topLeft.Equals(topRight) && topRight.Equals(bottomLeft) && bottomLeft.Equals(bottomRight))
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
