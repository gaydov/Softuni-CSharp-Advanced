using System;
using System.Text.RegularExpressions;

namespace ExtractQuotations
{
    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"('|"")(.*?)\1";

            MatchCollection results = Regex.Matches(input, pattern);
            foreach (Match match in results)
            {
                Console.WriteLine(match.Groups[2]);
            }
        }
    }
}
