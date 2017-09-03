using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LittleJohn
{
    public class Launcher
    {
        public static void Main()
        {
            string validArrow = @"\>{1,3}\-{5}\>{1,2}";
            string largeArrowPatt = @"\>{3}\-{5}\>{2}";
            string meduimArrowPatt = @"\>{2}\-{5}\>{1}";
            string smallArrowPatt = @"\>{1}\-{5}\>{1}";

            int largeCount = 0;
            int mediumCount = 0;
            int smallCount = 0;

            for (int i = 0; i < 4; i++)
            {
                string input = Console.ReadLine();

                // for every row extacting only the valid arrows:
                MatchCollection validArrows = Regex.Matches(input, validArrow);

                foreach (Match arrow in validArrows)
                {
                    Match largeArrow = Regex.Match(arrow.ToString(), largeArrowPatt);
                    if (largeArrow.Success)
                    {
                        largeCount++;
                    }
                    else
                    {
                        Match mediumArrow = Regex.Match(arrow.ToString(), meduimArrowPatt);
                        if (mediumArrow.Success)
                        {
                            mediumCount++;
                        }
                        else
                        {
                            Match smallArrow = Regex.Match(arrow.ToString(), smallArrowPatt);
                            if (smallArrow.Success)
                            {
                                smallCount++;
                            }
                        }
                    }
                }
            }

            string concatCounts = string.Empty + smallCount + mediumCount + largeCount;
            string binary = Convert.ToString(int.Parse(concatCounts), 2);
            string binaryReversed = new string(binary.ToCharArray().Reverse().ToArray());
            string concatenatedResult = string.Empty + binary + binaryReversed;
            string decimalResult = Convert.ToInt32(concatenatedResult, 2).ToString();
            Console.WriteLine(decimalResult);
        }
    }
}
