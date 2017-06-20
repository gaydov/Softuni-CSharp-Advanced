using System;
using System.Collections.Generic;
using System.Linq;

namespace WeakStudents
{
    public class WeakStudents
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

            students.Where(s => s.Skip(2).Count(mark => int.Parse(mark) <= 3) >= 2)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s[0]} {s[1]}"));
        }
    }
}
