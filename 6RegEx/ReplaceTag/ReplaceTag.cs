using System;
using System.Text.RegularExpressions;

namespace ReplaceTag
{
    public class ReplaceTag
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"<a href=("".*?"")>(.*?)<\/a>";

            while (!input.Equals("end"))
            {
                string result = Regex.Replace(input, pattern, x => $@"[URL href={x.Groups[1]}]{x.Groups[2]}[/URL]");
                Console.WriteLine(result);
                input = Console.ReadLine();
            }
        }
    }
}
