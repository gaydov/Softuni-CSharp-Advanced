using System;
using System.Linq;

namespace DiagonalDifference
{
    public class Launcher
    {
        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rowsCount][];

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                int[] inputNums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[rowIndex] = inputNums;
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (rowIndex - colIndex == 0)
                    {
                        primaryDiagonal += matrix[rowIndex][colIndex];
                    }

                    if (rowIndex + colIndex == rowsCount - 1)
                    {
                        secondaryDiagonal += matrix[rowIndex][colIndex];
                    }
                }
            }

            int difference = Math.Abs(primaryDiagonal - secondaryDiagonal);
            Console.WriteLine(difference);
        }
    }
}
