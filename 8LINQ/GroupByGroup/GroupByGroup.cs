using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupByGroup
{
    public class GroupByGroup
    {
        public static void Main()
        {
            List<Person> students = new List<Person>();
            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                string[] args = input.Split();
                students.Add(new Person(args[0] + " " + args[1], int.Parse(args[2])));
                input = Console.ReadLine();
            }

            var studentsGrouped = students.GroupBy(s => s.GroupId)
                .OrderBy(g => g.Key);

            foreach (var group in studentsGrouped)
            {
                Console.Write($"{group.Key} - ");
                StringBuilder sb = new StringBuilder();

                foreach (Person person in group)
                {
                    sb.Append(person.Name + ", ");
                }

                Console.WriteLine(sb.ToString().TrimEnd(", ".ToCharArray()));
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int GroupId { get; set; }

        public Person(string name, int groupId)
        {
            this.Name = name;
            this.GroupId = groupId;
        }
    }
}
