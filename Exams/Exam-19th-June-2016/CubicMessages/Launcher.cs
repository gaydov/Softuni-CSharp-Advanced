using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CubicMessages
{
    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, string> messagesWithCodes = new Dictionary<string, string>();

            while (!input.Equals("Over!"))
            {
                int m = int.Parse(Console.ReadLine());
                string validMessagePattern = $@"^([\d]+)([a-zA-Z]{{{m}}})([^a-zA-Z]*)$";
                Match match = Regex.Match(input, validMessagePattern);

                if (!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }

                string message = match.Groups[2].ToString();
                string digitsBeforeTheMessage = match.Groups[1].ToString();
                string partAfterTheMessage = match.Groups[3].ToString();
                string digitsAfterTheMessage = Regex.Match(partAfterTheMessage, "\\d+").ToString();

                int[] allDigits = (digitsBeforeTheMessage + digitsAfterTheMessage)
                    .ToCharArray()
                    .Select(c => int.Parse(c.ToString()))
                    .ToArray();

                StringBuilder code = new StringBuilder();

                for (int i = 0; i < allDigits.Length; i++)
                {
                    int currentIndex = allDigits[i];

                    if (currentIndex >= 0 && currentIndex < message.Length)
                    {
                        code.Append(message[currentIndex]);
                    }
                    else
                    {
                        code.Append(" ");
                    }
                }

                messagesWithCodes.Add(message, code.ToString());

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, string> resultMessage in messagesWithCodes)
            {
                Console.WriteLine($"{resultMessage.Key} == {resultMessage.Value}");
            }
        }
    }
}
