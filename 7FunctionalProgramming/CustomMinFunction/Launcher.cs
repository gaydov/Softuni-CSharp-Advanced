using System;
using System.Linq;

namespace CustomMinFunction
{
    public class Launcher
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> findMin = n => n.Min();
            Console.WriteLine(findMin(numbers));
        }
    }
}
