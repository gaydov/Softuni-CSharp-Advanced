using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseString
{
    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> reversed = new Stack<char>(input.ToCharArray());
            StringBuilder result = new StringBuilder();

            while (reversed.Count != 0)
            {
                result.Append(reversed.Pop());
            }

            Console.WriteLine(result);
        }
    }
}
