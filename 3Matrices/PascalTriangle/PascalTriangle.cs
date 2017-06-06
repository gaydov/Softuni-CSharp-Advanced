using System;

namespace PascalTriangle
{
    public class PascalTriangle
    {
        public static void Main()
        {
            int height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];

            int currentWidth = 1;

            for (int i = 0; i < height; i++)
            {
                triangle[i] = new long[currentWidth];
                long[] currentRow = triangle[i];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                currentWidth++;

                if (currentRow.Length > 2)
                {
                    for (int j = 1; j < currentRow.Length - 1; j++)
                    {
                        long[] previousRow = triangle[i - 1];
                        long sumOfElementsPrevRow = previousRow[j] + previousRow[j - 1];
                        currentRow[j] = sumOfElementsPrevRow;
                    }
                }
            }

            foreach (long[] row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
