using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    public class Launcher
    {
        public static void Main()
        {
            string pattern = @"\+359( |-)2\1[0-9]{3}\1[0-9]{4}\b";
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
