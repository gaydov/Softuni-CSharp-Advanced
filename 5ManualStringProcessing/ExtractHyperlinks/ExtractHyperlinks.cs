using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractHyperlinks
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            StringBuilder text = new StringBuilder();
            string pattern = @"<a([^>]+?)href\s*=\s*(""|'|\s?)(.+?)\2(?=\s{1}|>)";
            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                text.Append(input);
                input = Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(text.ToString(), pattern);

            foreach (Match hyperlink in matches)
            {
                Console.WriteLine(hyperlink.Groups[3]);
            }
        }
    }
}
