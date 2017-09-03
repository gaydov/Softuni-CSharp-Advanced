using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    public class Launcher
    {
        public static void Main()
        {
            string[] parameters = Console.ReadLine().Split();
            int numsToDequeue = int.Parse(parameters[1]);
            int elementToBeChecked = int.Parse(parameters[2]);
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(nums);

            for (int i = 0; i < numsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count > 0)
            {
                if (queue.Contains(elementToBeChecked))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
