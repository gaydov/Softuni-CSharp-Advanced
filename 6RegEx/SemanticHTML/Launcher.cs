using System;
using System.Text.RegularExpressions;

namespace SemanticHTML
{
    public class Launcher
    {
        public static void Main()
        {
            string openTagPattern = @"<(div)([^>]*)(?:id|class)\s*=\s*""(.*?)""(.*?)>";
            string closeTagPattern = @"<\/div>\s*<!--\s*(.*?)\s*-->";
            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                Match openTagMatch = Regex.Match(input, openTagPattern);
                Match closeTagMatch = Regex.Match(input, closeTagPattern);

                if (openTagMatch.Success)
                {
                    input = Regex.Replace(input, openTagPattern, i => $"{i.Groups[3]} {i.Groups[2]} {i.Groups[4]}").Trim();
                    input = "<" + Regex.Replace(input, @"\s+", " ") + ">";
                }
                else if (closeTagMatch.Success)
                {
                    input = $"</{closeTagMatch.Groups[1]}>";
                }

                Console.WriteLine(input);

                input = Console.ReadLine();
            }
        }
    }
}
