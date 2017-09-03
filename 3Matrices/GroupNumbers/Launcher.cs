using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupNumbers
{
    public class Launcher
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] matrix = new int[3][];

            List<int> remainder0 = new List<int>();
            List<int> remainder1 = new List<int>();
            List<int> remainder2 = new List<int>();

            foreach (var num in numbers)
            {
                if (Math.Abs(num) % 3 == 0)
                {
                    remainder0.Add(num);
                }
                else if (Math.Abs(num) % 3 == 1)
                {
                    remainder1.Add(num);
                }
                else if (Math.Abs(num) % 3 == 2)
                {
                    remainder2.Add(num);
                }
            }

            matrix[0] = remainder0.ToArray();
            matrix[1] = remainder1.ToArray();
            matrix[2] = remainder2.ToArray();

            Console.WriteLine(string.Join(" ", matrix[0]));
            Console.WriteLine(string.Join(" ", matrix[1]));
            Console.WriteLine(string.Join(" ", matrix[2]));
        }
    }
}
