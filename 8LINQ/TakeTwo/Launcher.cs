using System;
using System.Linq;

namespace TakeTwo
{
    public class Launcher
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => n >= 10 && n <= 20)
                .Distinct()
                .Take(2)
                .ToArray();

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
