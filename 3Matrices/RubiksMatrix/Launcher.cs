using System;
using System.Linq;

namespace RubiksMatrix
{
    public class Launcher
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            int commandsCount = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rowsCount][];
            int num = 1;

            for (int rowsIndex = 0; rowsIndex < matrix.Length; rowsIndex++)
            {
                matrix[rowsIndex] = new int[colsCount];

                for (int coIndex = 0; coIndex < matrix[rowsIndex].Length; coIndex++)
                {
                    matrix[rowsIndex][coIndex] = num;
                    num++;
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int col = 0;
                int row = 0;
                string direction = cmdArgs[1];
                int rotations = int.Parse(cmdArgs[2]);

                switch (direction)
                {
                    case "up":
                        col = int.Parse(cmdArgs[0]);
                        RotateUp(matrix, col, rotations);
                        break;

                    case "down":
                        col = int.Parse(cmdArgs[0]);
                        RotateDown(matrix, col, rotations);
                        break;

                    case "right":
                        row = int.Parse(cmdArgs[0]);
                        RotateRight(matrix, row, rotations);
                        break;

                    case "left":
                        row = int.Parse(cmdArgs[0]);
                        RotateLeft(matrix, row, rotations);
                        break;
                }
            }

            RearrangeMatrix(matrix);
        }

        private static void RearrangeMatrix(int[][] matrix)
        {
            int correctNum = 1; // what the number on that position should be

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    bool isSwaped = false; // boolean variable required in order to know when a number is swapped and to terminate the loop

                    if (matrix[rowIndex][colIndex] != correctNum)
                    {
                        int wrongNum = matrix[rowIndex][colIndex]; // getting the current number on that position (wrong one)

                        // start searching for the correct number
                        for (int searchedRow = rowIndex; searchedRow < matrix.Length; searchedRow++) 
                        {
                            if (isSwaped)
                            {
                                break;
                            }

                            for (int searchedCol = 0; searchedCol < matrix[rowIndex].Length; searchedCol++)
                            {
                                // when we find the correct number we replace it with the wrong one
                                if (matrix[searchedRow][searchedCol].Equals(correctNum)) 
                                {
                                    matrix[rowIndex][colIndex] = matrix[searchedRow][searchedCol];
                                    matrix[searchedRow][searchedCol] = wrongNum;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({searchedRow}, {searchedCol})");
                                    isSwaped = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }

                    correctNum++;
                }
            }
        }

        private static void RotateUp(int[][] matrix, int col, int rotations)
        {
            for (int i = 0; i < rotations % matrix.Length; i++)
            {
                int firstElement = matrix[0][col];

                for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
                {
                    matrix[rowIndex][col] = matrix[rowIndex + 1][col];
                }

                matrix[matrix.Length - 1][col] = firstElement;
            }
        }

        private static void RotateDown(int[][] matrix, int col, int rotations)
        {
            for (int i = 0; i < rotations % matrix.Length; i++)
            {
                int lastElement = matrix[matrix.Length - 1][col];

                for (int rowIndex = matrix.Length - 1; rowIndex > 0; rowIndex--)
                {
                    matrix[rowIndex][col] = matrix[rowIndex - 1][col];
                }

                matrix[0][col] = lastElement;
            }
        }

        private static void RotateRight(int[][] matrix, int row, int rotations)
        {
            for (int i = 0; i < rotations % matrix[row].Length; i++)
            {
                int lastElement = matrix[row][matrix[row].Length - 1];

                for (int colIndex = matrix[row].Length - 1; colIndex > 0; colIndex--)
                {
                    matrix[row][colIndex] = matrix[row][colIndex - 1];
                }

                matrix[row][0] = lastElement;
            }
        }

        private static void RotateLeft(int[][] matrix, int row, int rotations)
        {
            for (int i = 0; i < rotations % matrix[row].Length; i++)
            {
                int firstElement = matrix[row][0];

                for (int colIndex = 0; colIndex < matrix[row].Length - 1; colIndex++)
                {
                    matrix[row][colIndex] = matrix[row][colIndex + 1];
                }

                matrix[row][matrix[row].Length - 1] = firstElement;
            }
        }
    }
}
