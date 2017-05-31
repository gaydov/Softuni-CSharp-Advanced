using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    public class CountSameValuesInArray
    {
        public static void Main()
        {
            double[] nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            SortedDictionary<double, int> numsWithCount = new SortedDictionary<double, int>();

            foreach (double number in nums)
            {
                if (!numsWithCount.ContainsKey(number))
                {
                    numsWithCount.Add(number, 1);
                }
                else
                {
                    numsWithCount[number]++;
                }
            }

            foreach (KeyValuePair<double, int> number in numsWithCount)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
