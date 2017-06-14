using System;
using System.Linq;

namespace CountUppercaseWords
{
    public class CountUppercaseWords
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> checkUpperCase = w => w[0].Equals(w.ToUpper()[0]);

            words.Where(checkUpperCase)
               .ToList()
               .ForEach(w => Console.WriteLine(w));
        }
    }
}
