using System.Collections.Generic;
using System.Linq;
using BashSoft.StaticData;

namespace BashSoft.Repository
{
    public static class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();

            if (comparison.Equals("ascending"))
            {
                PrintStudents(wantedData
                    .OrderBy(x => x.Value.Sum())
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison.Equals("descending"))
            {
                PrintStudents(wantedData
                    .OrderByDescending(x => x.Value.Sum())
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private static void PrintStudents(Dictionary<string, List<int>> studentsSorted)
        {
            foreach (var student in studentsSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }
    }
}
