using System;

namespace RecursiveFibonacci
{
    public class Launcher
    {
        private static long[] fibNumbers;

        public static void Main()
        {
            int lastNum = int.Parse(Console.ReadLine());
            fibNumbers = new long[lastNum];
            long result = GetFibRecursively(lastNum);

            Console.WriteLine(result);
        }

        private static long GetFibRecursively(long ntnNum)
        {
            if (ntnNum <= 2)
            {
                return 1;
            }

            if (fibNumbers[ntnNum - 1] != 0)
            {
                return fibNumbers[ntnNum - 1];
            }

            return fibNumbers[ntnNum - 1] = GetFibRecursively(ntnNum - 1) + GetFibRecursively(ntnNum - 2);
        }
    }
}
