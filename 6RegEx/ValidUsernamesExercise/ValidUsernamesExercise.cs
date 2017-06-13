using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ValidUsernamesExercise
{
    public class ValidUsernamesExercise
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\b[a-zA-Z][a-zA-Z\d_]{2,24}\b";
            string[] usernamesMatchesArr = Regex.Matches(input, pattern)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();

            int maxLength = 0;
            int bestIndex = 0;

            for (int i = 0; i < usernamesMatchesArr.Length - 1; i++)
            {
                if (usernamesMatchesArr[i].Length + usernamesMatchesArr[i + 1].Length > maxLength)
                {
                    maxLength = usernamesMatchesArr[i].Length + usernamesMatchesArr[i + 1].Length;
                    bestIndex = i;
                }
            }

            Console.WriteLine(usernamesMatchesArr[bestIndex]);
            Console.WriteLine(usernamesMatchesArr[bestIndex + 1]);
        }
    }
}
