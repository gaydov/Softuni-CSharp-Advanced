using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    public class MatchingBrackets
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals('('))
                {
                    stack.Push(i);
                }
                else if (input[i].Equals(')'))
                {
                    int startIndex = stack.Pop();
                    string result = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
