using System;
using System.Linq;

namespace FirstName
{
    public class FirstName
    {
        public static void Main()
        {
            string[] names = Console.ReadLine().Split();
            string[] letters = Console.ReadLine().Split().OrderBy(l => l).ToArray();

            string resultName = string.Empty;

            foreach (string letter in letters)
            {
                resultName = names.Where(name => name.ToLower().StartsWith(letter.ToLower())).FirstOrDefault();

                if (resultName != null)
                {
                    Console.WriteLine(resultName);
                    break;
                }
            }

            if (resultName == null)
            {
                Console.WriteLine("No match");
            }
        }
    }
}
