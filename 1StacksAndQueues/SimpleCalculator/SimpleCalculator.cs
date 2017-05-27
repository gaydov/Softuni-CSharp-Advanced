using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    public class SimpleCalculator
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                double firstNum = double.Parse(stack.Pop());
                string oper = stack.Pop();
                double secondNum = double.Parse(stack.Pop());

                switch (oper)
                {
                    case "+":
                        stack.Push((firstNum + secondNum).ToString());
                        break;
                    case "-":
                        stack.Push((firstNum - secondNum).ToString());
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
