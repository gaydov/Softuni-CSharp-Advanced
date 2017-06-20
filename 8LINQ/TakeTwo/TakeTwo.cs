using System;
using System.Linq;

namespace TakeTwo
{
    public class TakeTwo
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => 10 <= n && n <= 20)
                .Distinct()
                .Take(2)
                .ToArray();

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
