using System;
using System.IO;

namespace LineNumbers
{
    public class Launcher
    {
        // The files should be put in the project's directory (e.g. D:\Softuni2\CSharp fundamentals\Streams\LineNumbers)
        private const string FilePathSource = "../../source.txt";
        private const string FilePathTarget = "../../destination.txt";

        public static void Main()
        {
            using (StreamReader reader = new StreamReader(FilePathSource))
            {
                using (StreamWriter writer = new StreamWriter(FilePathTarget))
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