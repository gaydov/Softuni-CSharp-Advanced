using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    public class Launcher
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<Dragon>> dragons = new Dictionary<string, List<Dragon>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string inputType = input[0];
                string inputName = input[1];
                string inputDamage = input[2];
                string inputHealth = input[3];
                string inputArmor = input[4];

                Dragon currentDragon = new Dragon();
                currentDragon.Name = inputName;

                if (!inputDamage.Equals("null"))
                {
                    currentDragon.Damage = double.Parse(inputDamage);
                }

                if (!inputHealth.Equals("null"))
                {
                    currentDragon.Health = double.Parse(inputHealth);
                }

                if (!inputArmor.Equals("null"))
                {
                    currentDragon.Armor = double.Parse(inputArmor);
                }

                if (!dragons.ContainsKey(inputType))
                {
                    dragons.Add(inputType, new List<Dragon>());
                    dragons[inputType].Add(currentDragon);
                }
                else
                {
                    if (dragons[inputType].FirstOrDefault(d => d.Name.Equals(currentDragon.Name)) == null)
                    {
                        dragons[inputType].Add(currentDragon);
                    }
                    else
                    {
                        dragons[inputType].FirstOrDefault(d => d.Name.Equals(currentDragon.Name)).Damage = currentDragon.Damage;
                        dragons[inputType].FirstOrDefault(d => d.Name.Equals(currentDragon.Name)).Health = currentDragon.Health;
                        dragons[inputType].FirstOrDefault(d => d.Name.Equals(currentDragon.Name)).Armor = currentDragon.Armor;
                    }
                }
            }

            PrintResults(dragons);
        }

        private static void PrintResults(Dictionary<string, List<Dragon>> dragons)
        {
            foreach (KeyValuePair<string, List<Dragon>> dragonType in dragons)
            {
                double avgDamage = dragonType.Value.Select(d => d.Damage).Average();
                double avgHealth = dragonType.Value.Select(d => d.Health).Average();
                double avgArmor = dragonType.Value.Select(d => d.Armor).Average();

                Console.WriteLine($"{dragonType.Key}::({avgDamage:F2}/{avgHealth:F2}/{avgArmor:F2})");

                foreach (Dragon dragon in dragons[dragonType.Key].OrderBy(d => d.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }
}
