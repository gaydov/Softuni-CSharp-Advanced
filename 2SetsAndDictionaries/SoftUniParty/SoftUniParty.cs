using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    public class SoftUniParty
    {
        public static void Main()
        {
            string guestNumber = Console.ReadLine();
            SortedSet<string> guests = new SortedSet<string>();

            while (guestNumber != "PARTY")
            {
                guests.Add(guestNumber);

                guestNumber = Console.ReadLine();
            }

            while (guestNumber != "END")
            {
                guests.Remove(guestNumber);

                guestNumber = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);

            foreach (string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
