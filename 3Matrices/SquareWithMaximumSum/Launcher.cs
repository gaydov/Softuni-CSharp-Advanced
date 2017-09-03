using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    public class Launcher
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[dimensions[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                int[] row = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[i] = row;
            }

            int maxRow = 0;
            int maxCol = 0;
            int maxSum = int.MinValue;

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    int currentSum = matrix[i][j] + matrix[i][j + 1] + matrix[i + 1][j] + matrix[i + 1][j + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow][maxCol]} {matrix[maxRow][maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1][maxCol]} {matrix[maxRow + 1][maxCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
