using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    public class Launcher
    {
        public static void Main()
        {
            int[] setsSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = setsSizes[0];
            SortedSet<int> nSet = new SortedSet<int>();

            for (int i = 0; i < n; i++)
            {
                nSet.Add(int.Parse(Console.ReadLine()));
            }

            int m = setsSizes[1];
            SortedSet<int> mSet = new SortedSet<int>();

            for (int i = 0; i < m; i++)
            {
                mSet.Add(int.Parse(Console.ReadLine()));
            }

            var result = nSet.Intersect(mSet);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
