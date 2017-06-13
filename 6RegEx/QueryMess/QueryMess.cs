using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QueryMess
{
    public class QueryMess
    {
        public static void Main()
        {
            string pairsPattern = @"[^&?=]+=[^&?=]+";
            string emptySpacePattern = @"(%20|\+)+";
            string input = Console.ReadLine();
            Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();

            while (!input.Equals("END"))
            {
                MatchCollection matches = Regex.Matches(input, pairsPattern);
                foreach (Match match in matches)
                {
                    string[] args = match.ToString().Split('=');
                    string field = args[0];
                    field = Regex.Replace(field, emptySpacePattern, " ").Trim();
                    string value = args[1];
                    value = Regex.Replace(value, emptySpacePattern, " ").Trim();

                    if (!results.ContainsKey(field))
                    {
                        results.Add(field, new List<string>());
                        results[field].Add(value);
                    }
                    else
                    {
                        results[field].Add(value);
                    }
                }

                foreach (var pair in results)
                {
                    Console.Write($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                }

                results = new Dictionary<string, List<string>>();
                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
    }
}
