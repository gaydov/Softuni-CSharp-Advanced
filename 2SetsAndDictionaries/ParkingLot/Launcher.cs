using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ParkingLot
{
    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            SortedSet<string> cars = new SortedSet<string>();

            while (input != "END")
            {
                string[] commandArgs = Regex.Split(input, ", ");
                string command = commandArgs[0];
                string plateNumber = commandArgs[1];

                if (command.Equals("IN"))
                {
                    cars.Add(plateNumber);
                }
                else if (command.Equals("OUT"))
                {
                    cars.Remove(plateNumber);
                }

                input = Console.ReadLine();
            }

            if (cars.Count > 0)
            {
                foreach (string car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
