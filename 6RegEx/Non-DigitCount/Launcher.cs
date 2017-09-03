using System;
using System.Text.RegularExpressions;

namespace Non_DigitCount
{
    public class Program
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"[^0-9]";

            MatchCollection matches = Regex.Matches(text, pattern);
            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}
