using System;
using System.Collections.Generic;
using System.IO;

namespace SlicingFile
{
    public class SlicingFile
    {
        private const string FilePath = "../../waterfall.jpg";
        private const string SplitFile = "../../Split parts/";
        private const string AssembledFilePath = "../../assembled.jpg";

        public static void Main()
        {
            // The files should be put in the project's directory (e.g. D:\Softuni2\CSharp fundamentals\Streams\SlicingFile)

            Console.Write("Parts count: ");
            int partsCount = int.Parse(Console.ReadLine());
            List<string> slicedFilesPaths = new List<string>();

            // If already exist, deleting the assembled file and the directory where the split files will be
            if (Directory.Exists(Path.GetDirectoryName(SplitFile)))
            {
                Directory.Delete(Path.GetDirectoryName(SplitFile), true);
            }

            if (File.Exists(AssembledFilePath))
            {
                File.Delete(AssembledFilePath);
            }

            Split(FilePath, SplitFile, partsCount, slicedFilesPaths);

            Console.WriteLine("{0}The file was split. Please press any key to continue with assemble...", Environment.NewLine);
            Console.ReadKey();

            Assemble(slicedFilesPaths, AssembledFilePath);

            Console.WriteLine("{0}The file was assembled.{0}", Environment.NewLine);
        }

        private static void Assemble(List<string> slicedFilesPaths, string assembleDir)
        {
            for (int i = 0; i < slicedFilesPaths.Count; i++)
            {
                using (FileStream reader = new FileStream(slicedFilesPaths[i], FileMode.Open))
                {
                    using (FileStream writer = new FileStream(assembleDir, FileMode.Append))
                    {
                        byte[] buffer = new byte[reader.Length];
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }

        private static void Split(string sourceFilePath, string destinationDir, int parts, List<string> slicedFilesPaths)
        {
            // Creating directory where the sliced files will be:
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                double partSize = Math.Ceiling((double)reader.Length / parts);

                for (int i = 1; i <= parts; i++)
                {
                    using (FileStream writer = new FileStream(destinationDir + $"Part-{i}", FileMode.Create))
                    {
                        byte[] buffer = new byte[(int)partSize];
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, readBytes);
                        slicedFilesPaths.Add(destinationDir + $"Part-{i}");
                    }
                }
            }
        }
    }
}
