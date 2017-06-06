using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            // The files should be put in the project's directory (e.g. D:\Softuni2\CSharp fundamentals\Streams\LineNumbers)

            const string filePathSource = "../../source.txt";
            const string filePathTarget = "../../destination.txt";

            using (StreamReader reader = new StreamReader(filePathSource))
            {
                using (StreamWriter writer = new StreamWriter(filePathTarget))
                {
                    int lineNumber = 1;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine($"{lineNumber}. {line}");
                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
            }
            Console.WriteLine("{0}Done.{0}", Environment.NewLine);
        }
    }
}
