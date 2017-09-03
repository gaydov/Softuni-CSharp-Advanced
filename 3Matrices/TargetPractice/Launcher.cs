using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    public class Launcher
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            char[] snake = Console.ReadLine().ToCharArray();
            int[] impactArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int impactRow = impactArgs[0];
            int impactCol = impactArgs[1];
            int radius = impactArgs[2];
            char[][] matrix = new char[rowsCount][];

            int snakeCounter = 0;
            int rowCounter = 0;

            FillingMatrix(colsCount, snake, matrix, snakeCounter, rowCounter);

            // Using Pythagorean Theorem to determine if an element is affected by the blast:
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    double distance = Math.Sqrt(Math.Pow(colIndex - impactCol, 2) + Math.Pow(rowIndex - impactRow, 2));

                    // the element is in the radius so we replace it with empty space
                    if (distance <= radius)
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
            }

            FallDownElements(matrix);

            // Printing the result:
            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }

        private static void FillingMatrix(int colsCount, char[] snake, char[][] matrix, int snakeCounter, int rowCounter)
        {
            //// filling in the matrix - when on an odd rowCounter index we start from the rightmost element 
            //// and when on an even rowCounter index we start from the leftmost element:

            for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
            {
                matrix[rowIndex] = new char[colsCount];
                rowCounter++;

                if (rowCounter % 2 != 0)
                {
                    for (int colIndex = matrix[rowIndex].Length - 1; colIndex >= 0; colIndex--)
                    {
                        matrix[rowIndex][colIndex] = snake[snakeCounter % snake.Length];
                        snakeCounter++;
                    }
                }
                else
                {
                    for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        matrix[rowIndex][colIndex] = snake[snakeCounter % snake.Length];
                        snakeCounter++;
                    }
                }
            }
        }

        private static void FallDownElements(char[][] matrix)
        {
            for (int colIndex = matrix[0].Length - 1; colIndex >= 0; colIndex--)
            {
                List<char> collapsed = new List<char>(); // the list will contain the collapsed elements + the required count of empty spaces
                int emptySpaceCounter = 0;

                for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
                {
                    if (matrix[rowIndex][colIndex].Equals(' '))
                    {
                        emptySpaceCounter++;
                    }
                    else
                    {
                        collapsed.Add(matrix[rowIndex][colIndex]);
                    }
                }

                for (int i = 0; i < emptySpaceCounter; i++)
                {
                    collapsed.Add(' ');
                }

                // replacing the elements in the matrix with the elements from the list:
                for (int rowIndex = matrix.Length - 1; rowIndex >= 0; rowIndex--)
                {
                    matrix[rowIndex][colIndex] = collapsed[collapsed.Count - 1 - rowIndex];
                }
            }
        }
    }
}
