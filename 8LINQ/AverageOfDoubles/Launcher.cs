using System;
using System.Linq;

namespace AverageOfDoubles
{
    public class Launcher
    {
        public static void Main()
        {
            double avg = Console.ReadLine().Split().Select(double.Parse).Average();
            Console.WriteLine($"{avg:F2}");
        }
    }
}
