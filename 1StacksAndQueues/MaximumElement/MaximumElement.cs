using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    public class MaximumElement
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            int biggestNum = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0].Equals("1"))
                {
                    int num = int.Parse(command[1]);
                    stack.Push(num);

                    if (num > biggestNum)
                    {
                        biggestNum = num;
                    }
                }
                else if (command[0].Equals("2"))
                {
                    stack.Pop();

                    if (stack.Count > 0)
                    {
                        biggestNum = stack.Max();
                    }
                }
                else if (command[0].Equals("3"))
                {
                    Console.WriteLine(biggestNum);
                }
            }
        }
    }
}
