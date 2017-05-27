using System;

namespace RecursiveFibonacci
{
    public class RecursiveFibonacci
    {
        private static long[] fibNumbers;

        public static void Main()
        {
            int NtnNum = int.Parse(Console.ReadLine());
            fibNumbers = new long[NtnNum];
            long result = GetFibRecursively(NtnNum);

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
