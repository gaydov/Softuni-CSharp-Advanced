using System;
using System.Text.RegularExpressions;

namespace VowelCount
{
    public class Launcher
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"[aoueiyAOUEIY]";

            MatchCollection matches = Regex.Matches(text, pattern);
            Console.WriteLine($"Vowels: {matches.Count}");
        }
    }
}
