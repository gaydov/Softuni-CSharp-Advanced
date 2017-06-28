using System;
using System.Collections.Generic;
using System.Linq;
using BashSoft.StaticData;

namespace BashSoft.Repository
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter.Equals("excellent"))
            {
                FilterAndTake(wantedData, x => x >= 5.00, studentsToTake);
            }
            else if (wantedFilter.Equals("average"))
            {
                FilterAndTake(wantedData, x => 3.5 <= x && x < 5.00, studentsToTake);
            }
            else if (wantedFilter.Equals("poor"))
            {
                FilterAndTake(wantedData, x => x < 3.50, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int countedForPrinted = 0;
            foreach (var usernamePoints in wantedData)
            {
                double averageScore = usernamePoints.Value.Average();
                double percentageOfFullfilment = averageScore / 100;
                double mark = percentageOfFullfilment * 4 + 2;

                if (givenFilter(mark))
                {
                    OutputWriter.PrintStudent(usernamePoints);
                    countedForPrinted++;
                }
            }
        }


        private static double Average(List<int> scoresOnTasks)
        {
            double totalScore = 0;
            foreach (int score in scoresOnTasks)
            {
                totalScore += score;
            }

            double percentageOfAll = totalScore / (scoresOnTasks.Count * 100);
            double mark = percentageOfAll * 4 + 2;

            return mark;
        }
    }
}
