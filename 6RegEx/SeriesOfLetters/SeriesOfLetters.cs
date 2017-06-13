using System;
using System.Text.RegularExpressions;

namespace SeriesOfLetters
{
    public class SeriesOfLetters
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"([a-zA-Z])\1+";
            string result = Regex.Replace(input, pattern, c => c.Groups[1].ToString());
            Console.WriteLine(result);
        }
    }
}
