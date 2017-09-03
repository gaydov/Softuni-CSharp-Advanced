using System;
using System.Collections.Generic;
using System.Linq;

namespace MapDistricts
{
    public class Launcher
    {
        public static void Main()
        {
            string[] cities = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long bound = long.Parse(Console.ReadLine());

            Dictionary<string, List<long>> citiesWithPopulation = new Dictionary<string, List<long>>();

            foreach (string inputCity in cities)
            {
                string[] args = inputCity.Split(':');
                string cityName = args[0];
                long population = long.Parse(args[1]);

                if (!citiesWithPopulation.ContainsKey(cityName))
                {
                    citiesWithPopulation.Add(cityName, new List<long>());
                }

                citiesWithPopulation[cityName].Add(population);
            }

            Dictionary<string, List<long>> filteredCities = citiesWithPopulation
                .Where(c => c.Value.Sum() > bound)
                .OrderByDescending(c => c.Value.Sum())
                .ToDictionary(c => c.Key, c => c.Value);

            foreach (var city in filteredCities)
            {
                Console.Write($"{city.Key}: ");

                foreach (long district in city.Value.OrderByDescending(p => p).Take(5))
                {
                    Console.Write(district + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
