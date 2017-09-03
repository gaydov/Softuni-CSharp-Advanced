using System;

namespace StringLength
{
    public class Launcher
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            if (text.Length < 20)
            {
                text = text.PadRight(20, '*');
            }
            else
            {
                text = text.Substring(0, 20);
            }

            Console.WriteLine(text);
        }
    }
}
