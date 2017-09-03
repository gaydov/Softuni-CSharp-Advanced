using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    public class Launcher
    {
        public static void Main()
        {
            string num1 = Console.ReadLine().TrimStart('0');
            int num2 = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            int remainder = 0;

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(num1[i].ToString());

                if ((currentDigit * num2) + remainder < 10)
                {
                    result.Insert(0, (currentDigit * num2) + remainder);
                    remainder = 0;
                }
                else
                {
                    int lastDigit = ((currentDigit * num2) + remainder) % 10;
                    result.Insert(0, lastDigit);
                    remainder = ((currentDigit * num2) + remainder) / 10;
                }
            }

            if (remainder != 0)
            {
                result.Insert(0, remainder);
            }

            if (result.ToString().All(d => d.Equals('0')))
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
