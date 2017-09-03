using System;

namespace ParseTags
{
    public class Launcher
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int indexOpenTag = text.IndexOf("<upcase>");

            while (indexOpenTag != -1)
            {
                int indexCloseTag = text.IndexOf("</upcase>");
                if (indexCloseTag == -1)
                {
                    break;
                }

                string tobeReplaced = text.Substring(indexOpenTag, indexCloseTag - indexOpenTag + "</upcase>".Length);
                string upperCase = tobeReplaced.Replace("<upcase>", string.Empty);
                upperCase = upperCase.Replace("</upcase>", string.Empty);
                upperCase = upperCase.ToUpper();
                text = text.Replace(tobeReplaced, upperCase);
                indexOpenTag = text.IndexOf("<upcase>");
            }

            Console.WriteLine(text);
        }
    }
}
