using System;
using System.Linq;

namespace SortEvenNumbers
{
    public class SortEvenNumbers
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int[] evenNumsSorted = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .Where(n => n % 2 == 0).OrderBy(n => n).ToArray();

            Console.WriteLine(string.Join(", ", evenNumsSorted));
        }
    }
}
