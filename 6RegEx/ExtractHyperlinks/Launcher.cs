using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractHyperlinks
{
    public class Launcher
    {
        public static void Main()
        {
            string pattern = @"<a\s+[^>]*?href\s*=(.*?)>.*?<\s*\/\s*a\s*>";
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            while (!input.Equals("END"))
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(sb.ToString(), pattern);

            foreach (Match match in matches)
            {
                string possibleHref = match.Groups[1].ToString().Trim();
                string result = string.Empty;

                if (possibleHref[0].Equals('"'))
                {
                    result = possibleHref.Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries).First();
                }
                else if (possibleHref[0] == '\'')
                {
                    result = possibleHref.Split(new char[] { '\'' }, StringSplitOptions.RemoveEmptyEntries).First();
                }
                else
                {
                    result = possibleHref.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).First();
                }

                Console.WriteLine(result);
            }
        }
    }
}