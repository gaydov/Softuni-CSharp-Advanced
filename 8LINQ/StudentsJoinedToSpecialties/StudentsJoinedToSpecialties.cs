using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsJoinedToSpecialties
{
    public class StudentsJoinedToSpecialties
    {
        public static void Main()
        {
            List<StudentSpecialty> specialties = new List<StudentSpecialty>();
            List<Student> students = new List<Student>();
            string input = Console.ReadLine();

            while (!input.Equals("Students:"))
            {
                string[] args = input.Split();
                specialties.Add(new StudentSpecialty(args[0] + " " + args[1], int.Parse(args[2])));
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                string[] args = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                students.Add(new Student(args[1] + " " + args[2], int.Parse(args[0])));
                input = Console.ReadLine();
            }

            var result = specialties
                .Join(students,
                    sp => sp.FacNumber,
                    st => st.FacNumber,
                    (sp, st) => new
                    {
                        FacultyNum = sp.FacNumber,
                        StudentName = st.StudentName,
                        SpecName = sp.SpecialtyName
                    });

            foreach (var joinResult in result.OrderBy(r => r.StudentName))
            {
                Console.WriteLine($"{joinResult.StudentName} {joinResult.FacultyNum} {joinResult.SpecName}");
            }
        }
    }

    public class StudentSpecialty
    {
        public string SpecialtyName { get; set; }
        public int FacNumber { get; set; }

        public StudentSpecialty(string specialtyName, int facNum)
        {
            this.SpecialtyName = specialtyName;
            this.FacNumber = facNum;
        }
    }

    public class Student
    {
        public string StudentName { get; set; }
        public int FacNumber { get; set; }

        public Student(string studentName, int facNum)
        {
            this.StudentName = studentName;
            this.FacNumber = facNum;
        }
    }
}
