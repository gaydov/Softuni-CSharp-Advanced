using System;
using System.Collections.Generic;

namespace SpecialWords
{
    public class Launcher
    {
        public static void Main()
        {
            char[] separators = "()[]<>,-!? (‘’)".ToCharArray();
            Dictionary<string, int> wordsWithCount = new Dictionary<string, int>();
            string[] specialWords = Console.ReadLine().Split();
            string text = Console.ReadLine();
            string[] textSplit = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in specialWords)
            {
                if (!wordsWithCount.ContainsKey(word))
                {
                    wordsWithCount.Add(word, 0);
                }

                foreach (string splitWord in textSplit)
                {
                    if (word.Equals(splitWord))
                    {
                        wordsWithCount[word]++;
                    }
                }
            }

            foreach (KeyValuePair<string, int> pair in wordsWithCount)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
