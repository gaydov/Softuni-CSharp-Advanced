using System;
using System.Collections.Generic;

namespace HotPotato
{
    public class Launcher
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int cycle = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            foreach (string child in input)
            {
                queue.Enqueue(child);
            }

            int counter = 1;
            while (queue.Count > 1)
            {
                if (counter == cycle)
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                    counter = 0;
                }
                else
                {
                    string passedChild = queue.Dequeue();
                    queue.Enqueue(passedChild);
                }

                counter++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
