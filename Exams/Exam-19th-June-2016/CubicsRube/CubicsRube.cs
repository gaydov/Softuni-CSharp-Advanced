using System;

namespace CubicsRube
{
    public class CubicsRube
    {
        public static void Main()
        {
            int cubeSide = int.Parse(Console.ReadLine());
            double totalCells = Math.Pow(cubeSide, 3);
            int changedCellsCount = 0;
            long sum = 0;
            string input = Console.ReadLine();

            while (!input.Equals("Analyze"))
            {
                string[] args = input.Split();
                int x = int.Parse(args[0]);
                int y = int.Parse(args[1]);
                int z = int.Parse(args[2]);
                int valueToBeAdded = int.Parse(args[3]);

                bool isInside = (0 <= x && x < cubeSide) && (0 <= y && y < cubeSide) && (0 <= z && z < cubeSide);
                if (!isInside)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (valueToBeAdded != 0)
                {
                    changedCellsCount++;
                }

                sum += valueToBeAdded;
                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
            Console.WriteLine(totalCells - changedCellsCount);
        }
    }
}
