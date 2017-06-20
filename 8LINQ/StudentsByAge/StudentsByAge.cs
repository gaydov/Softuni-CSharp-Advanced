using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsByAge
{
    public class StudentsByAge
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

            students.Where(st => 18 <= int.Parse(st[2]) && int.Parse(st[2]) <= 24)
                .ToList()
                .ForEach(st => Console.WriteLine(string.Join(" ", st)));
        }
    }
}
