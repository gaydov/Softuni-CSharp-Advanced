using System;
using System.Collections.Generic;
using System.Linq;

namespace FixEmails
{
    public class Launcher
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            Dictionary<string, string> namesWithEmails = new Dictionary<string, string>();

            while (!name.Equals("stop"))
            {
                string email = Console.ReadLine();

                namesWithEmails.Add(name, email);

                name = Console.ReadLine();
            }

            // added ToList() to avoid "Collection was modified" exception
            foreach (KeyValuePair<string, string> entry in namesWithEmails.ToList()) 
            {
                if (entry.Value.EndsWith("us") || entry.Value.EndsWith("uk"))
                {
                    namesWithEmails.Remove(entry.Key);
                }
            }

            foreach (KeyValuePair<string, string> entry in namesWithEmails)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }
    }
}
