using System;
using System.Text;

namespace UnicodeCharacters
{
    public class Launcher
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();
            StringBuilder result = new StringBuilder();

            foreach (var symbol in input)
            {
                result.Append("\\u" + ((int)symbol).ToString("x4"));
            }

            Console.WriteLine(result);
        }
    }
}
