using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            char[] validParentheses = { '(', '{', '[' };
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (validParentheses.Contains(input[i]))
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    switch (input[i])
                    {
                        case ')':
                            if (!stack.Pop().Equals('('))
                            {
                                Console.WriteLine("NO");
                                return;
                            }

                            break;

                        case '}':
                            if (!stack.Pop().Equals('{'))
                            {
                                Console.WriteLine("NO");
                                return;
                            }

                            break;

                        case ']':
                            if (!stack.Pop().Equals('['))
                            {
                                Console.WriteLine("NO");
                                return;
                            }

                            break;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
