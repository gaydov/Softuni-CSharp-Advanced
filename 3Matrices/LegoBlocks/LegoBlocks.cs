using System;
using System.Linq;

namespace LegoBlocks
{
    public class LegoBlocks
    {
        public static void Main()
        {
            int rowsInArr = int.Parse(Console.ReadLine());
            int[][] firstArr = new int[rowsInArr][];

            for (int i = 0; i < firstArr.Length; i++)
            {
                firstArr[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int[][] secondArr = new int[rowsInArr][];

            for (int i = 0; i < secondArr.Length; i++)
            {
                secondArr[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Array.Reverse(secondArr[i]);
            }

            // combining both arrays into one:
            int[][] combined = new int[rowsInArr][];

            for (int i = 0; i < combined.Length; i++)
            {
                combined[i] = new int[firstArr[i].Length + secondArr[i].Length];
                firstArr[i].CopyTo(combined[i], 0);
                secondArr[i].CopyTo(combined[i], firstArr[i].Length);
            }

            bool isSymetric = true;

            for (int i = 0; i < combined.Length - 1; i++)
            {
                if (combined[i].Length != combined[i + 1].Length)
                {
                    isSymetric = false;
                    break;
                }
            }

            if (isSymetric)
            {
                for (int i = 0; i < combined.Length; i++)
                {
                    Console.WriteLine($"[{string.Join(", ", combined[i])}]");
                }
            }
            else
            {
                int counter = 0;

                for (int i = 0; i < combined.Length; i++)
                {
                    counter += combined[i].Length;
                }

                Console.WriteLine($"The total number of cells is: {counter}");
            }
        }
    }
}
