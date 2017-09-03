using System;
using System.Collections.Generic;

namespace Palindromes
{
    public class Launcher
    {
        public static void Main()
        {
            string[] text = Console.ReadLine().Split(" ,.?!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> set = new SortedSet<string>();

            foreach (var word in text)
            {
                char[] wordCharArr = word.ToCharArray();
                Array.Reverse(wordCharArr);
                string reversedWord = new string(wordCharArr);

                if (word.Equals(reversedWord))
                {
                    set.Add(word);
                }
            }

            Console.WriteLine($"[{string.Join(", ", set)}]");
        }
    }
}
