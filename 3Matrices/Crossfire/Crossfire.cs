using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    public class Crossfire
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];

            List<List<int>> matrix = new List<List<int>>();
            int counter = 1;

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                matrix.Add(new List<int>());
                for (int colIndex = 0; colIndex < colsCount; colIndex++)
                {
                    matrix[rowIndex].Add(counter);
                    counter++;
                }
            }

            string command = Console.ReadLine();
            while (command != "Nuke it from orbit")
            {
                int[] cmdArgs = command.Split().Select(int.Parse).ToArray();
                int targetRow = cmdArgs[0];
                int targetCol = cmdArgs[1];
                int radius = cmdArgs[2];

                Nuke(matrix, targetRow, targetCol, radius);
                RemoveEmptyCells(matrix);

                command = Console.ReadLine();
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static void Nuke(List<List<int>> matrix, int targetRow, int targetCol, int radius)
        {
            // horizontal
            if (targetRow >= 0 && targetRow < matrix.Count)
            {
                for (int colIndex = Math.Max(0, targetCol - radius); colIndex <= Math.Min(targetCol + radius, matrix[targetRow].Count - 1); colIndex++)
                {
                    matrix[targetRow][colIndex] = 0;
                }
            }

            // vertical
            if (targetCol >= 0 && targetCol < matrix[0].Count)
            {
                for (int rowIndex = Math.Max(0, targetRow - radius); rowIndex <= Math.Min(targetRow + radius, matrix.Count - 1); rowIndex++)
                {
                    if (targetCol < matrix[rowIndex].Count)
                    {
                        matrix[rowIndex][targetCol] = 0;
                    }
                }
            }
        }

        private static void RemoveEmptyCells(List<List<int>> matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
            {
                List<int> currentRow = matrix[rowIndex].Where(n => n > 0).ToList();

                if (currentRow.Count > 0)
                {
                    currentRow.RemoveAll(n => n == 0);
                    matrix[rowIndex] = currentRow;
                }
                else
                {
                    matrix.RemoveAt(rowIndex);
                    rowIndex--;
                }
            }
        }
    }
}
