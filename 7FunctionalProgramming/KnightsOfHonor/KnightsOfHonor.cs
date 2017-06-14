using System;

namespace KnightsOfHonor
{
    public class KnightsOfHonor
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Action<string> addTitleSir = n => Console.WriteLine($"Sir {n}");

            foreach (string name in input)
            {
                addTitleSir(name);
            }
        }
    }
}
