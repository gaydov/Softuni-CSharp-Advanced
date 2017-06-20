using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsByGroup
{
    public class StudentsByGroup
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

            students.Where(st => st[2].Equals("2"))
                .OrderBy(st => st[0])
                .ToList()
                .ForEach(st => Console.WriteLine($"{st[0]} {st[1]}"));
        }
    }
}
