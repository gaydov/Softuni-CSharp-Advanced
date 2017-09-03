using System;
using System.Collections.Generic;
using System.Text;

namespace JediMeditation
{
    public class Launcher
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> masters = new Queue<string>();
            Queue<string> knights = new Queue<string>();
            Queue<string> padawans = new Queue<string>();
            Queue<string> toshkoSlavs = new Queue<string>();
            bool hasYodaAppeared = false;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                foreach (string jedi in input)
                {
                    char firstLetter = jedi[0];

                    if (firstLetter.Equals('m'))
                    {
                        masters.Enqueue(jedi);
                    }
                    else if (firstLetter.Equals('k'))
                    {
                        knights.Enqueue(jedi);
                    }
                    else if (firstLetter.Equals('p'))
                    {
                        padawans.Enqueue(jedi);
                    }
                    else if (firstLetter.Equals('t') || firstLetter.Equals('s'))
                    {
                        toshkoSlavs.Enqueue(jedi);
                    }
                    else if (firstLetter.Equals('y'))
                    {
                        hasYodaAppeared = true;
                    }
                }
            }

            string toshkoSlavsString = string.Join(" ", toshkoSlavs.ToArray());
            string mastersString = string.Join(" ", masters.ToArray());
            string knightsString = string.Join(" ", knights.ToArray());
            string padawansString = string.Join(" ", padawans.ToArray());

            StringBuilder result = new StringBuilder();

            if (!hasYodaAppeared)
            {
                result.Append(toshkoSlavsString).Append(" ");
                result.Append(mastersString).Append(" ");
                result.Append(knightsString).Append(" ");
                result.Append(padawansString);
            }
            else
            {
                result.Append(mastersString).Append(" ");
                result.Append(knightsString).Append(" ");
                result.Append(toshkoSlavsString).Append(" ");
                result.Append(padawansString);
            }

            Console.WriteLine(result);
        }
    }
}
