using System;
using System.Text.RegularExpressions;

namespace SentenceExtractor
{
    public class Launcher
    {
        public static void Main()
        {
            string validSentencePattern = @"(?:\s|^)(.*?[.|!|?])";
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            MatchCollection validSentences = Regex.Matches(text, validSentencePattern);

            foreach (Match sentence in validSentences)
            {
                Match wordMatch = Regex.Match(sentence.ToString(), $@"\b{word}\b");
                if (wordMatch.Success)
                {
                    Console.WriteLine(sentence);
                }
            }
        }
    }
}
