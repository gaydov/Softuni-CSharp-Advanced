using System;
using System.Linq;

namespace UpperStrings
{
    public class Launcher
    {
        public static void Main()
        {
            string[] input = Console.ReadLine()
                .Split()
                .Select(s => s.ToUpper())
                .ToArray();

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
