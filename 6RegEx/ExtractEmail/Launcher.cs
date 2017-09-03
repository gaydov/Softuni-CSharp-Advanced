using System;
using System.Text.RegularExpressions;

namespace ExtractEmail
{
    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"(?:^|\s)([a-zA-Z0-9][\-\._a-zA-Z0-9]*)@[a-zA-Z\-]+(\.[a-z]+)+\b";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString().Trim());
            }
        }
    }
}
