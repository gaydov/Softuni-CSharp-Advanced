using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogs
{
    public class UserLogs
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, int>> logs = new SortedDictionary<string, Dictionary<string, int>>();

            while (!input.Equals("end"))
            {
                string[] args = input.Split(new char[] { '=', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string IP = args[1];
                string user = args[args.Length - 1];

                if (!logs.ContainsKey(user))
                {
                    logs[user] = new Dictionary<string, int> { { IP, 1 } };
                }
                else
                {
                    if (!logs[user].ContainsKey(IP))
                    {
                        logs[user].Add(IP, 1);
                    }
                    else
                    {
                        logs[user][IP]++;
                    }
                }

                input = Console.ReadLine();
            }

            PrintResults(logs);
        }

        private static void PrintResults(SortedDictionary<string, Dictionary<string, int>> logs)
        {
            foreach (var user in logs)
            {
                Console.WriteLine($"{user.Key}:");

                Console.WriteLine("{0}.", string.Join(", ", user.Value.Select(x => $"{x.Key} => {x.Value}")));
            }
        }
    }
}
