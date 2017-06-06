using System;
using System.Linq;

namespace MaximalSum
{
    public class MaximalSum
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            int[][] matrix = new int[rowsCount][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            long maxSum = long.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int rownIndex = 0; rownIndex < matrix.Length - 2; rownIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rownIndex].Length - 2; colIndex++)
                {
                    long currentSquareSum =
                        matrix[rownIndex][colIndex] + matrix[rownIndex][colIndex + 1] + matrix[rownIndex][colIndex + 2] +
                        matrix[rownIndex + 1][colIndex] + matrix[rownIndex + 1][colIndex + 1] + matrix[rownIndex + 1][colIndex + 2] +
                        matrix[rownIndex + 2][colIndex] + matrix[rownIndex + 2][colIndex + 1] + matrix[rownIndex + 2][colIndex + 2];

                    if (currentSquareSum > maxSum)
                    {
                        maxSum = currentSquareSum;
                        maxRow = rownIndex;
                        maxCol = colIndex;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");

            for (int rowIndex = maxRow; rowIndex < maxRow + 3; rowIndex++)
            {
                for (int colIndex = maxCol; colIndex < maxCol + 3; colIndex++)
                {
                    Console.Write($"{matrix[rowIndex][colIndex]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
