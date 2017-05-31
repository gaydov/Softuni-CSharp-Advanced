using System;
using System.Collections.Generic;

namespace AMinersTask
{
    public class AMinersTask
    {
        public static void Main()
        {
            string resource = Console.ReadLine();
            Dictionary<string, int> resourcesWithQuantity = new Dictionary<string, int>();

            while (!resource.Equals("stop"))
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!resourcesWithQuantity.ContainsKey(resource))
                {
                    resourcesWithQuantity.Add(resource, quantity);
                }
                else
                {
                    resourcesWithQuantity[resource] += quantity;
                }

                resource = Console.ReadLine();
            }

            foreach (KeyValuePair<string, int> material in resourcesWithQuantity)
            {
                Console.WriteLine($"{material.Key} -> {material.Value}");
            }
        }
    }
}
