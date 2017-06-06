using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        // The files should be put in the project's directory (e.g. D:\Softuni2\CSharp fundamentals\Streams\OddLines)
        const string filePath = "../../source.txt";

        public static void Main()
        {
            StreamReader reader = new StreamReader(filePath);

            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine($"{line}");
                    }

                    line = reader.ReadLine();
                    lineNumber++;
                }
            }
            Console.WriteLine();
        }
    }
}
