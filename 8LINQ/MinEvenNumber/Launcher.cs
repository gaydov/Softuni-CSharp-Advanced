using System;
using System.Linq;

namespace MinEvenNumber
{
    public class Launcher
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Where(n => n % 2 == 0)
                .ToArray();

            if (numbers.Length > 0)
            {
                Console.WriteLine($"{numbers.Min():F2}");
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
