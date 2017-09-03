using System;
using System.Linq;

namespace AppliedArithmetics
{
    public class Launcher
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            Func<int[], int[]> add = n => n.Select(x => x + 1).ToArray();
            Func<int[], int[]> multiply = n => n.Select(x => x * 2).ToArray();
            Func<int[], int[]> subtract = n => n.Select(x => x - 1).ToArray();
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            while (!input.Equals("end"))
            {
                switch (input)
                {
                    case "add":
                        numbers = add.Invoke(numbers);
                        break;

                    case "multiply":
                        numbers = multiply.Invoke(numbers);
                        break;

                    case "subtract":
                        numbers = subtract.Invoke(numbers);
                        break;

                    case "print":
                        print.Invoke(numbers);
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
