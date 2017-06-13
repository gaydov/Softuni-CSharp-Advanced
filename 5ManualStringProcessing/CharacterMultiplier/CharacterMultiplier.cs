using System;

namespace CharacterMultiplier
{
    public class CharacterMultiplier
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int product = CharMultiplier(input);
            Console.WriteLine(product);
        }

        private static int CharMultiplier(string input)
        {
            string[] strings = input.Split();
            string firstString = strings[0];
            string secondString = strings[1];
            int length = Math.Max(firstString.Length, secondString.Length);
            int result = 0;

            for (int i = 0; i < length; i++)
            {
                int firstStrCharASCII = 1;
                int secondStrCharASCII = 1;

                if (i < firstString.Length)
                {
                    firstStrCharASCII = firstString[i];
                }
                if (i < secondString.Length)
                {
                    secondStrCharASCII = secondString[i];
                }
                result += firstStrCharASCII * secondStrCharASCII;
            }
            return result;
        }
    }
}
