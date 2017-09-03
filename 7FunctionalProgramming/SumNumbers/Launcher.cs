using System;
using System.Linq;

namespace SumNumbers
{
    public class Launcher
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Console.WriteLine(nums.Length);
            Console.WriteLine(nums.Sum());
        }
    }
}
