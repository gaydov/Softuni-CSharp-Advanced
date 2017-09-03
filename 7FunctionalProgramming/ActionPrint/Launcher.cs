using System;

namespace ActionPrint
{
    public class Launcher
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Action<string> print = s => Console.WriteLine(s);

            foreach (string name in input)
            {
                print(name);
            }
        }
    }
}
