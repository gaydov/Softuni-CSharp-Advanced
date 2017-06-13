using System;
using System.Numerics;

namespace ConvertFrombase_Ntobase_10
{
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int baseValue = int.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);
            int power = 0;
            BigInteger result = 0;

            while (number > 0)
            {
                int mostRightDigit = (int)(number % 10);
                BigInteger currentNum = mostRightDigit * BigInteger.Pow(baseValue, power);
                result += currentNum;
                power++;
                number = number / 10;
            }
            Console.WriteLine(result);
        }
    }
}
