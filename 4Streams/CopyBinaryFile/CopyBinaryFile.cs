using System;
using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        public static void Main()
        {
            // The files should be put in the project's directory (e.g. D:\Softuni2\CSharp fundamentals\Streams\CopyBinaryFile)
            const string sourceFilePath = "../../Penguins.jpg";
            const string destinationFilePath = "../../Penguins-copy.jpg";

            using (var sourceStream = new FileStream(sourceFilePath, FileMode.Open) )
            {
                using (var destinationStream = new FileStream(destinationFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = sourceStream.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destinationStream.Write(buffer, 0, readBytes);
                    }
                }
            }
            Console.WriteLine("{0}Done.{0}", Environment.NewLine);
        }
    }
}
