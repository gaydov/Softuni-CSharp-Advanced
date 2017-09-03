using System;
using System.Text;
using System.Text.RegularExpressions;

namespace UseYourChainsBuddy
{
    public class Launcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string betweenTagsContent = @"<p>(.*?)<\/p>";
            string smallLettersAndNumsOnly = @"[^a-z\d]";
            StringBuilder sb = new StringBuilder();

            MatchCollection matches = Regex.Matches(input, betweenTagsContent);
            foreach (Match match in matches)
            {
                string currentWord = Regex.Replace(match.Groups[1].ToString(), smallLettersAndNumsOnly, " ");
                currentWord = Regex.Replace(currentWord, @"\s+", " ");
                sb.Append(currentWord);
            }

            string decryptedText = sb.ToString();
            StringBuilder encryptedText = new StringBuilder();

            foreach (char symbol in decryptedText)
            {
                if (symbol >= 'a' && symbol <= 'm')
                {
                    encryptedText.Append((char)(symbol + 13));
                }
                else if (symbol >= 'n' && symbol <= 'z')
                {
                    encryptedText.Append((char)(symbol - 13));
                }
                else
                {
                    encryptedText.Append(symbol);
                }
            }

            Console.WriteLine(encryptedText);
        }
    }
}
