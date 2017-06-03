using System;
using System.Collections.Generic;

namespace LogsAggregator
{
    public class Session
    {
        public SortedSet<string> IPs { get; set; }
        public int Duration { get; set; }
    }

    public class LogsAggregator
    {
        public static void Main()
        {
            SortedDictionary<string, Session> usersWithSessions = new SortedDictionary<string, Session>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string IP = input[0];
                string user = input[1];
                int duration = int.Parse(input[2]);

                if (!usersWithSessions.ContainsKey(user))
                {
                    usersWithSessions.Add(user, new Session());
                    usersWithSessions[user].IPs = new SortedSet<string>();
                    usersWithSessions[user].IPs.Add(IP);
                    usersWithSessions[user].Duration = duration;
                }
                else
                {
                    if (!usersWithSessions[user].IPs.Contains(IP))
                    {
                        usersWithSessions[user].IPs.Add(IP);
                        usersWithSessions[user].Duration += duration;
                    }
                    else
                    {
                        usersWithSessions[user].Duration += duration;
                    }
                }
            }

            PrintResults(usersWithSessions);
        }

        private static void PrintResults(SortedDictionary<string, Session> usersWithSessions)
        {
            foreach (KeyValuePair<string, Session> user in usersWithSessions)
            {
                Console.WriteLine($"{user.Key}: {user.Value.Duration} [{string.Join(", ", user.Value.IPs)}]");
            }
        }
    }
}
