using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    public class Launcher
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> uniqueElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();

                for (int j = 0; j < elements.Length; j++)
                {
                    uniqueElements.Add(elements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueElements));
        }
    }
}
