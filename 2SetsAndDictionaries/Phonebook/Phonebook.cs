using System;
using System.Collections.Generic;

namespace Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split('-');
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (!input[0].Equals("search"))
            {
                string name = input[0];
                string number = input[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name, number);
                }
                else
                {
                    phonebook[name] = number;
                }

                input = Console.ReadLine().Split('-');
            }

            string searchedName = Console.ReadLine();

            while (!searchedName.Equals("stop"))
            {
                if (phonebook.ContainsKey(searchedName))
                {
                    Console.WriteLine($"{searchedName} -> {phonebook[searchedName]}");
                }
                else
                {
                    Console.WriteLine($"Contact {searchedName} does not exist.");
                }

                searchedName = Console.ReadLine();
            }
        }
    }
}
