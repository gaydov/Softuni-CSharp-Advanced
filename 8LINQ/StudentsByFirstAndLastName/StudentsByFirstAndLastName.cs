using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsByFirstAndLastName
{
    public class StudentsByFirstAndLastName
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<string[]> students = new List<string[]>();

            while (!input.Equals("END"))
            {
                students.Add(input.Split());
                input = Console.ReadLine();
            }

            students.Where(st => String.Compare(st[0], st[1]) == -1)
                .ToList()
                .ForEach(st => Console.WriteLine($"{st[0]} {st[1]}"));
        }
    }
}
