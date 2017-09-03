using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationCounter
{
    public class Launcher
    {
        public static void Main()
        {
            Dictionary<string, List<City>> countriesWithCities = new Dictionary<string, List<City>>();
            string input = Console.ReadLine();

            while (!input.Equals("report"))
            {
                string[] args = input.Split('|');
                string cityName = args[0];
                string countryName = args[1];
                long population = long.Parse(args[2]);

                City currentCity = new City
                {
                    Name = cityName,
                    Population = population
                };

                if (!countriesWithCities.ContainsKey(countryName))
                {
                    countriesWithCities.Add(countryName, new List<City>());
                    countriesWithCities[countryName].Add(currentCity);
                }
                else
                {
                    if (countriesWithCities[countryName].FirstOrDefault(c => c.Name.Equals(cityName)) == null)
                    {
                        countriesWithCities[countryName].Add(currentCity);
                    }
                    else
                    {
                        countriesWithCities[countryName].FirstOrDefault(c => c.Name.Equals(cityName)).Population += population;
                    }
                }

                input = Console.ReadLine();
            }

            PrintResults(countriesWithCities);
        }

        private static void PrintResults(Dictionary<string, List<City>> countriesWithCities)
        {
            foreach (KeyValuePair<string, List<City>> country in countriesWithCities.OrderByDescending(country => country.Value.Select(city => city.Population).Sum()))
            {
                long totalPopulaton = country.Value.Select(c => c.Population).Sum();
                Console.WriteLine($"{country.Key} (total population: {totalPopulaton})");

                foreach (City city in country.Value.OrderByDescending(c => c.Population))
                {
                    Console.WriteLine($"=>{city.Name}: {city.Population}");
                }
            }
        }
    }
}
