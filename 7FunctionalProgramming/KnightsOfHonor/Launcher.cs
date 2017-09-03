using System;

namespace KnightsOfHonor
{
    public class Launcher
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Action<string> addTitleSir = n => Console.WriteLine($"Sir {n}");

            foreach (string name in input)
            {
                addTitleSir(name);
            }
        }
    }
}
