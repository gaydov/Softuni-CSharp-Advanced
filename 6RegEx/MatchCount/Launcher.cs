using System;
using System.Text.RegularExpressions;

namespace MatchCount
{
    public class Launcher
    {
        public static void Main()
        {
            string searchedWord = Console.ReadLine();
            string text = Console.ReadLine();

            MatchCollection occurences = Regex.Matches(text, searchedWord);
            Console.WriteLine(occurences.Count);
        }
    }
}
