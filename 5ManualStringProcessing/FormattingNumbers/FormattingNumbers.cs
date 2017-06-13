using System;

namespace FormattingNumbers
{
    public class FormattingNumbers
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int a = int.Parse(input[0]);
            double b = double.Parse(input[1]);
            double c = double.Parse(input[2]);

            string aHex = a.ToString("X");
            string aBin = Convert.ToString(a, 2);

            if (aBin.Length < 10)
            {
                aBin = aBin.PadLeft(10, '0');
            }
            else
            {
                while (aBin.Length > 10)
                {
                    aBin = aBin.Remove(aBin.Length - 1, 1);
                }
            }
            Console.WriteLine(string.Format("|{0, -10}|{1, 10}|{2,10:0.00}|{3,-10:0.000}|", aHex, aBin, b, c));
        }
    }
}
