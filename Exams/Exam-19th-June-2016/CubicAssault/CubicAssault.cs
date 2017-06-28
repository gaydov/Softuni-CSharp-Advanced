using System;
using System.Collections.Generic;
using System.Linq;

namespace CubicAssault
{
    public class CubicAssault
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();

            while (!input.Equals("Count em all"))
            {
                string[] args = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string regionName = args[0];
                string type = args[1];
                long count = long.Parse(args[2]);

                if (!regions.ContainsKey(regionName))
                {
                    regions.Add(regionName, new Dictionary<string, long>());
                    regions[regionName].Add("Black", 0);
                    regions[regionName].Add("Red", 0);
                    regions[regionName].Add("Green", 0);
                    regions[regionName][type] += count;
                }
                else
                {
                    regions[regionName][type] += count;
                }

                if (regions[regionName]["Green"] >= 1000000)
                {
                    while (regions[regionName]["Green"] >= 1000000)
                    {
                        regions[regionName]["Green"] -= 1000000;
                        regions[regionName]["Red"]++;
                    }
                }

                if (regions[regionName]["Red"] >= 1000000)
                {
                    while (regions[regionName]["Red"] >= 1000000)
                    {
                        regions[regionName]["Red"] -= 1000000;
                        regions[regionName]["Black"]++;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var regionEntry in regions.OrderByDescending(r => r.Value["Black"]).ThenBy(r => r.Key.Length).ThenBy(r => r.Key))
            {
                Console.WriteLine(regionEntry.Key);

                foreach (var meteorType in regionEntry.Value.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
                {
                    Console.WriteLine($"-> {meteorType.Key} : {meteorType.Value}");
                }
            }
        }
    }
}










