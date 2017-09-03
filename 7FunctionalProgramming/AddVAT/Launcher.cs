using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    public class Launcher
    {
        public static void Main()
        {
            List<double> input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n *= 1.2)
                .ToList();

            input.ForEach(n => Console.WriteLine($"{n:F2}"));
        }
    }
}
