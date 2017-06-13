using System;
using System.Text.RegularExpressions;

namespace ExtractIntegerNumbers
{
    public class ExtractIntegerNumbers
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"[0-9]+";

            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
