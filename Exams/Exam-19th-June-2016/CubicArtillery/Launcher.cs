using System;
using System.Collections.Generic;

namespace CubicArtillery
{
    public class Launcher
    {
        public static void Main()
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            Queue<string> bunckers = new Queue<string>();
            Queue<int> weapons = new Queue<int>();
            int leftCapacity = maxCapacity;

            string input = Console.ReadLine();

            while (!input.Equals("Bunker Revision"))
            {
                string[] args = input.Split();
                foreach (var element in args)
                {
                    int currentWeapon;
                    bool isDigit = int.TryParse(element, out currentWeapon);

                    if (!isDigit)
                    {
                        bunckers.Enqueue(element);
                    }
                    else
                    {
                        bool isWeaponSaved = false;

                        while (bunckers.Count > 1)
                        {
                            if (leftCapacity >= currentWeapon)
                            {
                                weapons.Enqueue(currentWeapon);
                                leftCapacity -= currentWeapon;
                                isWeaponSaved = true;
                                break;
                            }

                            if (weapons.Count == 0)
                            {
                                Console.WriteLine($"{bunckers.Dequeue()} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine($"{bunckers.Dequeue()} -> {string.Join(", ", weapons)}");
                                weapons.Clear();
                                leftCapacity = maxCapacity;
                            }
                        }

                        if (!isWeaponSaved)
                        {
                            if (currentWeapon <= maxCapacity)
                            {
                                while (leftCapacity < currentWeapon)
                                {
                                    leftCapacity += weapons.Dequeue();
                                }

                                weapons.Enqueue(currentWeapon);
                                leftCapacity -= currentWeapon;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
