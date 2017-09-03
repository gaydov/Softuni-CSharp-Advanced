using System;
using System.Numerics;
using System.Text;

namespace ConvertFrombase_10tobase_N
{
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int baseValue = int.Parse(input[0]);
            BigInteger number = BigInteger.Parse(input[1]);
            int remainder = 0;
            StringBuilder sb = new StringBuilder();

            while (number > 0)
            {
                remainder = (int)(number % baseValue);
                sb.Insert(0, remainder);
                number = number / baseValue;
            }

            Console.WriteLine(sb);
        }
    }
}
