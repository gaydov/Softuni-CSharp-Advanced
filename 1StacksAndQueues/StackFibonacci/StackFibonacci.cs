using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    public class StackFibonacci
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> fibNums = new Stack<long>();
            fibNums.Push(0);
            fibNums.Push(1);

            for (int i = 1; i < n; i++)
            {
                long popped = fibNums.Pop();
                long current = popped + fibNums.Peek();
                fibNums.Push(popped);
                fibNums.Push(current);
            }

            Console.WriteLine(fibNums.Peek());
        }
    }
}
