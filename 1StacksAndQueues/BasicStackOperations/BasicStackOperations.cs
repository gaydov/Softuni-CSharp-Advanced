using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    public class BasicStackOperations
    {
        public static void Main()
        {
            string[] parameters = Console.ReadLine().Split();
            int numsToBePopped = int.Parse(parameters[1]);
            int elementToBeChecked = int.Parse(parameters[2]);
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(nums);

            for (int i = 0; i < numsToBePopped; i++)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                if (stack.Contains(elementToBeChecked))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
