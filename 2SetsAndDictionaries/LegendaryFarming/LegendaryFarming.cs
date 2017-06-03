using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    public class LegendaryFarming
    {
        public static void Main()
        {

            Dictionary<string, int> materials = new Dictionary<string, int> { { "shards", 0 }, { "fragments", 0 }, { "motes", 0 } };
            Dictionary<string, int> junk = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split();

            while (true)
            {
                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string currentMaterial = input[i + 1].ToLower();

                    if (currentMaterial.Equals("shards") || currentMaterial.Equals("fragments") || currentMaterial.Equals("motes"))
                    {
                        if (materials.ContainsKey(currentMaterial))
                        {
                            materials[currentMaterial] += quantity;

                            if (materials[currentMaterial] >= 250)
                            {
                                materials[currentMaterial] -= 250;
                                PrintResults(currentMaterial, materials, junk);
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(currentMaterial))
                        {
                            junk.Add(currentMaterial, quantity);
                        }
                        else
                        {
                            junk[currentMaterial] += quantity;
                        }
                    }
                }

                input = Console.ReadLine().Split();
            }

        }

        private static void PrintResults(string currentMaterial, Dictionary<string, int> materials, Dictionary<string, int> junk)
        {
            switch (currentMaterial)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    break;

                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    break;

                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    break;
            }

            foreach (KeyValuePair<string, int> item in materials.OrderByDescending(i => i.Value).ThenBy(i => i.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (KeyValuePair<string, int> junkItem in junk.OrderBy(j => j.Key))
            {
                Console.WriteLine($"{junkItem.Key}: {junkItem.Value}");
            }
        }
    }
}
