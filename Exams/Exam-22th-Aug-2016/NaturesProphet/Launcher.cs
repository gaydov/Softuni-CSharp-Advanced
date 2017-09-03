using System;
using System.Linq;

namespace NaturesProphet
{
    public class Launcher
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rowsCoult = dimensions[0];
            int colsCount = dimensions[1];
            int[][] garden = new int[rowsCoult][];

            // creating the matrix
            for (int rowIndex = 0; rowIndex < garden.Length; rowIndex++)
            {
                garden[rowIndex] = new int[colsCount];
            }

            string position = Console.ReadLine();
            while (!position.Equals("Bloom Bloom Plow"))
            {
                int[] desiredPositionArgs = position.Split().Select(int.Parse).ToArray();
                int desiredRow = desiredPositionArgs[0];
                int desiredCol = desiredPositionArgs[1];

                // the flower on the desired position always blooms so its values always increases with 1
                garden[desiredRow][desiredCol] += 1;

                // blooming the flowers from up to down (the same column)
                for (int rowIndex = 0; rowIndex < garden.Length; rowIndex++)
                {
                    // skipping the desired row because the value there has been increased already
                    if (rowIndex == desiredRow)
                    {
                        continue;
                    }

                    if (garden[rowIndex][desiredCol] == 0)
                    {
                        garden[rowIndex][desiredCol] = 1;
                    }
                    else
                    {
                        garden[rowIndex][desiredCol] += 1;
                    }
                }

                // blooming from left to right (the same rown)
                for (int colIndex = 0; colIndex < garden[desiredRow].Length; colIndex++)
                {
                    // skipping the desired column because the value there has been increased already
                    if (colIndex == desiredCol)
                    {
                        continue;
                    }

                    if (garden[desiredRow][colIndex] == 0)
                    {
                        garden[desiredRow][colIndex] = 1;
                    }
                    else
                    {
                        garden[desiredRow][colIndex] += 1;
                    }
                }

                position = Console.ReadLine();
            }

            for (int rowIndex = 0; rowIndex < garden.Length; rowIndex++)
            {
                Console.WriteLine(string.Join(" ", garden[rowIndex]));
            }
        }
    }
}
