using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace JediDreams
{
    public class JediDreams
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> methods = new Dictionary<string, List<string>>();
            string methodNamePattern = @"static.*?([A-Z][a-zA-Z]*)\s*\(.*\)$";
            string invokePattern = @"([A-Z][a-zA-Z]*)\s*\(";
            string lastFoundMethod = string.Empty;
            bool atLeastOneMethodFound = false;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine().Trim();
                Match methodMatch = Regex.Match(input, methodNamePattern);

                if (methodMatch.Success)
                {
                    lastFoundMethod = methodMatch.Groups[1].ToString();
                    methods[lastFoundMethod] = new List<string>();
                    atLeastOneMethodFound = true;
                    continue;
                }
                if (atLeastOneMethodFound)
                {
                    MatchCollection invokeMatches = Regex.Matches(input, invokePattern);
                    if (invokeMatches.Count > 0)
                    {
                        foreach (Match invokeMatch in invokeMatches)
                        {
                            methods[lastFoundMethod].Add(invokeMatch.Groups[1].ToString());
                        }
                    }
                }
            }

            foreach (var method in methods.OrderByDescending(m => m.Value.Count).ThenBy(m => m.Key))
            {
                if (method.Value.Count > 0)
                {
                    Console.WriteLine($"{method.Key} -> {method.Value.Count} -> {string.Join(", ", method.Value.OrderBy(m => m))}");
                }
                else
                {
                    Console.WriteLine($"{method.Key} -> None");
                }
            }
        }
    }
}
