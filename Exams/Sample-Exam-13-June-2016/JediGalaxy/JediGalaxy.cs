using System;
using System.Linq;
using System.Net;
using System.Net.Configuration;

namespace JediGalaxy
{
    public class JediGalaxy
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            int[][] matrix = new int[rows][];

            int value = 0;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[columns];
                for (int colIndex = 0; colIndex < columns; colIndex++)
                {
                    matrix[rowIndex][colIndex] = value;
                    value++;
                }
            }

            long sum = 0;
            string input = Console.ReadLine();

            while (!input.Equals("Let the Force be with you"))
            {
                int[] ivoCoordinates = input.Split().Select(int.Parse).ToArray();
                input = Console.ReadLine();
                int[] evilCoordinates = input.Split().Select(int.Parse).ToArray();

                // evil instantly destroys the cells:
                int evilRow = evilCoordinates[0];
                int evilCol = evilCoordinates[1];

                while (evilRow != -1 && evilCol != -1)
                {
                    // checking if the cell is in the matrix:
                    if (IsCellInMatrix(evilRow, evilCol, matrix))
                    {
                        matrix[evilRow][evilCol] = 0;
                    }
                    // evil goes to the next cell - one row up and one column left
                    evilRow--;
                    evilCol--;
                }

                // Ivo starts to collect the stars:
                int ivoRow = ivoCoordinates[0];
                int ivoCol = ivoCoordinates[1];

                while (ivoRow >= 0 && ivoCol < matrix[0].Length)
                {
                    // checking if the cell is in the matrix:
                    if (IsCellInMatrix(ivoRow, ivoCol, matrix))
                    {
                        sum += matrix[ivoRow][ivoCol];
                    }

                    // Ivo goes to the next cell - one row up and one column right
                    ivoRow--;
                    ivoCol++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        public static bool IsCellInMatrix(int row, int col, int[][] matrix)
        {
            if (0 <= row && row < matrix.Length && 0 <= col && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
