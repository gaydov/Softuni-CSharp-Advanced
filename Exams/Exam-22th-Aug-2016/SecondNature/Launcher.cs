using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondNature
{
    public class Launcher
    {
        public static void Main()
        {
            int[] flowers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] buckets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> secondNature = new List<int>();

            int bucketIndex = buckets.Length - 1;
            int flowerIndex = 0;

            while (bucketIndex >= 0 && flowerIndex < flowers.Length)
            {
                if (flowers[flowerIndex] > buckets[bucketIndex])
                {
                    flowers[flowerIndex] -= buckets[bucketIndex];
                    buckets[bucketIndex] = 0;
                    bucketIndex--;
                }
                else if (flowers[flowerIndex] < buckets[bucketIndex])
                {
                    buckets[bucketIndex] -= flowers[flowerIndex];
                    flowers[flowerIndex] = 0;

                    if (bucketIndex != 0)
                    {
                        buckets[bucketIndex - 1] += buckets[bucketIndex];
                        buckets[bucketIndex] = 0;
                        bucketIndex--;
                    }

                    flowerIndex++;
                }
                else
                {
                    secondNature.Add(flowers[flowerIndex]);
                    buckets[bucketIndex] = 0;
                    flowers[flowerIndex] = 0;
                    bucketIndex--;
                    flowerIndex++;
                }
            }

            if (flowers.All(f => f == 0))
            {
                for (int i = buckets.Length - 1; i >= 0; i--)
                {
                    if (buckets[i] != 0)
                    {
                        Console.Write($"{buckets[i]} ");
                    }
                }
            }
            else
            {
                for (int i = 0; i < flowers.Length; i++)
                {
                    if (flowers[i] != 0)
                    {
                        Console.Write($"{flowers[i]} ");
                    }
                }
            }

            Console.WriteLine();

            if (secondNature.Count > 0)
            {
                Console.WriteLine(string.Join(" ", secondNature));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
