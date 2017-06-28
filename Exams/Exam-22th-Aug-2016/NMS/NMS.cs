using System;
using System.Collections.Generic;
using System.Text;

namespace NMS
{
    public class NMS
    {
        public static void Main()
        {
            List<string> resultWords = new List<string>();
            StringBuilder allLines = new StringBuilder();
            string input = Console.ReadLine();

            while (!input.Equals("---NMS SEND---"))
            {
                allLines.Append(input);
                input = Console.ReadLine();
            }

            string delimiter = Console.ReadLine();
            string message = allLines + " "; // adding extra empty string in order to be able to check the last char in the message

            StringBuilder possibleWord = new StringBuilder();

            for (int i = 0; i < message.Length - 1; i++)
            {
                char current = char.ToLower(message[i]);
                char next = char.ToLower(message[i + 1]);

                if (current <= next)
                {
                    possibleWord.Append(message[i]);
                }
                else
                {
                    possibleWord.Append(message[i]);
                    resultWords.Add(possibleWord.ToString());
                    possibleWord.Clear();
                }
            }

            Console.WriteLine(string.Join(delimiter, resultWords));
        }
    }
}
