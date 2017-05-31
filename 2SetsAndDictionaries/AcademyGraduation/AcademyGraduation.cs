using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyGraduation
{
    public class AcademyGraduation
    {
        public static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            SortedDictionary<string, List<double>> studentWithGrades = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string name = Console.ReadLine();
                List<double> grades = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();

                studentWithGrades.Add(name, grades);
            }

            foreach (KeyValuePair<string, List<double>> student in studentWithGrades)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}
