using System;
using System.Text.RegularExpressions;

namespace ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"^[\w-]{3,16}$";

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
