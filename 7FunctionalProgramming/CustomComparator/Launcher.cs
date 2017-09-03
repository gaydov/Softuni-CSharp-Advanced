using System;
using System.Linq;

namespace CustomComparator
{
    public class Launcher
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(nums, new EvenOrOddComparer());

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
