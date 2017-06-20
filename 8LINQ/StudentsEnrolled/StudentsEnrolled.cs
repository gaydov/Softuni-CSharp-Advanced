using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsEnrolled
{
    public class StudentsEnrolled
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

            students.Where(s => s[0].EndsWith("14") || s[0].EndsWith("15"))
                .Select(s => s.Skip(1))
                .ToList()
                .ForEach(s => Console.WriteLine(string.Join(" ", s)));
        }
    }
}
