using System;

namespace CountSubstringOccurrences
{
    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string pattern = Console.ReadLine().ToLower();
            int count = 0;

            int indexOfPattern = text.IndexOf(pattern);

            while (indexOfPattern != -1)
            {
                count++;
                indexOfPattern = text.IndexOf(pattern, indexOfPattern + 1);
            }
            Console.WriteLine(count);
        }
    }
}
