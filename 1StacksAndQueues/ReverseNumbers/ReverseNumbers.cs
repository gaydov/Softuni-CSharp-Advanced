using System;
using System.Collections.Generic;

namespace ReverseNumbers
{
    public class ReverseNumbers
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input);
            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} ");
            }
            Console.WriteLine();
        }
    }
}
