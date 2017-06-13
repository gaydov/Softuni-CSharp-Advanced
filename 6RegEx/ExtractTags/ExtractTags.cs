using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractTags
{
    public class ExtractTags
    {
        public static void Main()
        {
            string pattern = @"<.*?>";
            StringBuilder sb = new StringBuilder();

            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(sb.ToString(), pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
