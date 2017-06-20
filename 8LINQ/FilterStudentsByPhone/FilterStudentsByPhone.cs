using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterStudentsByPhone
{
    public class FilterStudentsByPhone
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

            students.Where(s => s[2].StartsWith("02") || s[2].StartsWith("+3592"))
                .ToList()
                .ForEach(s => Console.WriteLine($"{s[0]} {s[1]}"));
        }
    }
}
