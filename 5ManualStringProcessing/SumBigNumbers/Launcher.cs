using System;
using System.Text;

namespace SumBigNumbers
{
    public class Launcher
    {
        public static void Main()
        {
            string num1 = Console.ReadLine().TrimStart('0');
            string num2 = Console.ReadLine().TrimStart('0');
            StringBuilder result = new StringBuilder();

            if (num1.Length > num2.Length)
            {
                num2 = num2.PadLeft(num1.Length, '0');
            }
            else if (num2.Length > num1.Length)
            {
                num1 = num1.PadLeft(num2.Length, '0');
            }

            int remainder = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int num1Digit = int.Parse(num1[i].ToString());
                int num2Digit = int.Parse(num2[i].ToString());

                num1Digit += remainder;
                remainder = 0;

                if (num1Digit + num2Digit < 10)
                {
                    result.Insert(0, num1Digit + num2Digit);
                }
                else
                {
                    int lastDigit = (num1Digit + num2Digit) % 10;
                    result.Insert(0, lastDigit);
                    remainder = 1;
                }
            }

            if (remainder != 0)
            {
                result.Insert(0, remainder);
            }

            Console.WriteLine(result);
        }
    }
}
