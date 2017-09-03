using System;
using System.Linq;

namespace BoundedNumbers
{
    public class Launcher
    {
        public static void Main()
        {
            int[] bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            numbers.Where(n => bounds.Min() <= n && n <= bounds.Max())
                  .ToList()
                  .ForEach(n => Console.Write(n + " "));
            Console.WriteLine();
        }
    }
}
