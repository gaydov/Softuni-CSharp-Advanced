using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterStudentsByEmailDomain
{
    public class FilterStudentsByEmailDomain
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

            students.Where(s => s[2].EndsWith("gmail.com"))
                .ToList()
                .ForEach(s => Console.WriteLine($"{s[0]} {s[1]}"));
        }
    }
}
