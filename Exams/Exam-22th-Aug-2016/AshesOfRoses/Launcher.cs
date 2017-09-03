using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AshesOfRoses
{
    public class Launcher
    {
        public static void Main()
        {
            string pattern = @"^Grow <([A-Z][a-z]*)> <([A-Za-z\d]*)> ([\d]*)$";
            Dictionary<string, Dictionary<string, long>> regions = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();
            while (!input.Equals("Icarus, Ignite!"))
            {
                Match match = Regex.Match(input, pattern);
                if (!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }

                string region = match.Groups[1].ToString();
                string color = match.Groups[2].ToString();
                long rosesCount = long.Parse(match.Groups[3].ToString());

                if (!regions.ContainsKey(region))
                {
                    regions.Add(region, new Dictionary<string, long>());
                    regions[region].Add(color, rosesCount);
                }
                else
                {
                    if (!regions[region].ContainsKey(color))
                    {
                        regions[region].Add(color, rosesCount);
                    }
                    else
                    {
                        regions[region][color] += rosesCount;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var pair in regions.OrderByDescending(r => r.Value.Values.Sum()).ThenBy(r => r.Key))
            {
                Console.WriteLine(pair.Key);
                foreach (var colorPair in pair.Value.OrderBy(c => c.Value).ThenBy(c => c.Key))
                {
                    Console.WriteLine($"*--{colorPair.Key} | {colorPair.Value}");
                }
            }
        }
    }
}