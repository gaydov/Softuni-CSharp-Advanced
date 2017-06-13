using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsResults
{
    public class StudentsResults
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, double[]> students = new Dictionary<string, double[]>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int indexOfDash = input.IndexOf('-');
                string name = input.Substring(0, indexOfDash - 1);
                double[] grades = input.Substring(indexOfDash + 1).Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                students.Add(name, grades);
            }

            Console.WriteLine(string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));
            foreach (var student in students)
            {
                Console.WriteLine(string.Format("{0,-10}|{1,7:F2}|{2,7:F2}|{3,7:F2}|{4,7:F4}|", student.Key, student.Value[0], student.Value[1], student.Value[2], student.Value.Average()));
            }
        }
    }
}
