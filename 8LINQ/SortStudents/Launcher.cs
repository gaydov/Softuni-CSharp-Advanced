using System;
using System.Collections.Generic;
using System.Linq;

namespace SortStudents
{
    public class Launcher
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

            students.OrderBy(s => s[1])
                .ThenByDescending(s => s[0])
                .ToList()
                .ForEach(s => Console.WriteLine(string.Join(" ", s)));
        }
    }
}
