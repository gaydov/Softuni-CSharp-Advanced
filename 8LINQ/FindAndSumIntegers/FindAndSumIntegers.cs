using System;
using System.Collections.Generic;
using System.Linq;

namespace FindAndSumIntegers
{
    public class FindAndSumIntegers
    {
        public static void Main()
        {
            List<long> input = Console.ReadLine()
                .Split()
                .Select(n =>
                {
                    long value = 0;
                    bool isInt = long.TryParse(n, out value);
                    return new { value, isInt };
                })
                .Where(n => n.value != 0)
                .Select(n => n.value)
                .ToList();

            if (input.Count > 0)
            {
                Console.WriteLine(input.Sum());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
