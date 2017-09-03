using System;
using System.Collections.Generic;

namespace DecimalToBinaryConverter
{
    public class Launcher
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (input > 0)
            {
                while (input != 0)
                {
                    int remainder = input % 2;
                    stack.Push(remainder);
                    input /= 2;
                }

                while (stack.Count != 0)
                {
                    Console.Write(stack.Pop());
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
