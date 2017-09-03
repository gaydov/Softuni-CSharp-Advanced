using System;
using System.Collections.Generic;

namespace CountSymbols
{
    public class Launcher
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();
            SortedDictionary<char, int> lettersWithCount = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentLetter = input[i];

                if (!lettersWithCount.ContainsKey(currentLetter))
                {
                    lettersWithCount.Add(currentLetter, 1);
                }
                else
                {
                    lettersWithCount[currentLetter]++;
                }
            }

            foreach (var letter in lettersWithCount)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
