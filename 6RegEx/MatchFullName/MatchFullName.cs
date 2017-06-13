using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    public class MatchFullName
    {
        public static void Main()
        {
            string pattern = @"\b[A-Z]{1}[a-z]{1,} [A-Z]{1}[a-z]{1,}\b";
            string input = Console.ReadLine();
            while (!input.Equals("end"))
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}
