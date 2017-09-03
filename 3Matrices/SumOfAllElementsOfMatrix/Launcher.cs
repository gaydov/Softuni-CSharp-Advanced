using System;
using System.Linq;

namespace SumOfAllElementsOfMatrix
{
    public class Launcher
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] matrix = new int[dimensions[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                int[] rowElements = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[i] = rowElements;
            }

            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            int sum = 0;

            foreach (int[] row in matrix)
            {
                foreach (int element in row)
                {
                    sum += element;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
