using System;
using System.Text.RegularExpressions;

namespace ValidTime
{
    public class Launcher
    {
        public static void Main()
        {
            string pattern = @"([1][0-2]|[0][0-9]):[0-5][0-9]:[0-5][0-9] [A|P]M";
            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();
            }
        }
    }
}
