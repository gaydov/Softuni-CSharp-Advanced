using System;
using System.Linq;

namespace TriFunction
{
    public class TriFunction
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isLonger = (str, num) => str.ToCharArray().Select(c => (int)c).Sum() >= num;

            Func<string[], int, Func<string, int, bool>, string> findBiggestName = (arr, num, func) => arr.FirstOrDefault(s => func(s, num));

            string result = findBiggestName(names, n, isLonger);
            Console.WriteLine(result);
        }
    }
}
