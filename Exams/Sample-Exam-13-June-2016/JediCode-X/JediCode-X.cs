using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JediCode_X
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputLines = new string[n];
            StringBuilder lines = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                lines.Append(input);
            }

            string namesPattern = Console.ReadLine();
            string messagePattern = Console.ReadLine();
            int[] messagesIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string extractedNamesPattern = $@"{namesPattern}([a-zA-Z]{{{namesPattern.Length}}})(?![A-Za-z])";
            string extractedMessagesPattern = $@"{messagePattern}([a-zA-Z\d]{{{messagePattern.Length}}})(?![A-Za-z0-9])";

            Queue<string> names = new Queue<string>();
            List<string> messages = new List<string>();

            MatchCollection namesMatches = Regex.Matches(lines.ToString(), extractedNamesPattern);
            MatchCollection messagesMatches = Regex.Matches(lines.ToString(), extractedMessagesPattern);

            foreach (Match nameMatch in namesMatches)
            {
                names.Enqueue(nameMatch.Groups[1].ToString());
            }

            foreach (Match messageMatch in messagesMatches)
            {
                messages.Add(messageMatch.Groups[1].ToString());
            }

            Dictionary<string, string> jedisWithMessages = new Dictionary<string, string>();
            foreach (int index in messagesIndexes)
            {
                if (index - 1 < 0 || index - 1 > messages.Count - 1)
                {
                    continue;
                }

                if (names.Count > 0)
                {
                    string currentJedi = names.Dequeue();
                    jedisWithMessages.Add(currentJedi, messages[index - 1]);
                }
                else
                {
                    break;
                }
            }

            foreach (var jedi in jedisWithMessages)
            {
                Console.WriteLine($"{jedi.Key} - {jedi.Value}");
            }
        }
    }
}
