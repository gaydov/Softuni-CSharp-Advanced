using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    public class Launcher
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = input[0];
            int colsCount = input[1];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[][] matrix = new string[rowsCount][];

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                string[] row = new string[colsCount];
                for (int colIndex = 0; colIndex < colsCount; colIndex++)
                {
                    char firstAndLastLetter = alphabet[rowIndex];
                    char middleLetter = alphabet[rowIndex + colIndex];
                    row[colIndex] = string.Empty + firstAndLastLetter + middleLetter + firstAndLastLetter;
                    matrix[rowIndex] = row;
                }
            }

            foreach (string[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
