using System;
using System.Collections.Generic;

namespace MathPotato
{
    public class Launcher
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int number = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(input);

            int cycle = 1;
            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                if (IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }

                cycle++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        public static bool IsPrime(long num)
        {
            bool isPrime = true;

            if (num == 0 || num == 1)
            {
                isPrime = false;
            }
            else
            {
                for (int divisor = 2; divisor <= Math.Sqrt(num); divisor++)
                {
                    if (num % divisor == 0)
                    {
                        isPrime = false;
                    }
                }
            }

            return isPrime;
        }
    }
}