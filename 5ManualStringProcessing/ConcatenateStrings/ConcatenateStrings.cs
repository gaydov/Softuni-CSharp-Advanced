using System;
using System.Text;

namespace ConcatenateStrings
{
    public class ConcatenateStrings
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                sb.Append($"{word} ");
            }
            Console.WriteLine(sb);
        }
    }
}
