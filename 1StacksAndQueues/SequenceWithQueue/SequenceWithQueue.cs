using System;
using System.Collections.Generic;
using System.Text;

namespace SequenceWithQueue
{
    public class SequenceWithQueue
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();
            queue.Enqueue(n);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 50; i++)
            {
                long firstNum = queue.Peek();

                queue.Enqueue(firstNum + 1);
                queue.Enqueue(2 * firstNum + 1);
                queue.Enqueue(firstNum + 2);

                result.Append(queue.Dequeue() + " ");
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
