using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ZippingSlicedFiles
{
    public class ZippingSlicedFiles
    {
        // The files should be put in the project's directory (e.g. D:\Softuni2\CSharp fundamentals\Streams\ZippingSlicedFiles)

        private const string filePath = "../../waterfall.jpg";
        private const string splitFilesDir = "../../Split compressed parts/";
        private const string assembledFilePath = "../../waterfall decompressed.jpg";

        public static void Main()
        {

            Console.Write("Parts count: ");
            int partsCount = int.Parse(Console.ReadLine());

            List<string> splitFilesPaths = new List<string>();

            // If already exist, deleting the assembled file and the directory where the split files will be
            if (Directory.Exists(Path.GetDirectoryName(splitFilesDir)))
            {
                Directory.Delete(Path.GetDirectoryName(splitFilesDir), true);
            }

            if (File.Exists(assembledFilePath))
            {
                File.Delete(assembledFilePath);
            }

            Split(filePath, splitFilesDir, partsCount, splitFilesPaths);

            Console.WriteLine("{0}The file was split and the parts compressed. Please press any key to continue with assemble...", Environment.NewLine);
            Console.ReadKey();

            Assemble(splitFilesPaths, assembledFilePath);

            Console.WriteLine("{0}The file was decompressed and assembled.{0}", Environment.NewLine);
        }

        private static void Assemble(List<string> slicedFilesPaths, string assembleDir)
        {
            for (int i = 0; i < slicedFilesPaths.Count; i++)
            {
                using (FileStream reader = new FileStream(slicedFilesPaths[i], FileMode.Open))
                {
                    using (GZipStream decompressStream = new GZipStream(reader, CompressionMode.Decompress, false))
                    {
                        using (FileStream writer = new FileStream(assembleDir, FileMode.Append))
                        {
                            byte[] buffer = new byte[4096];

                            while (true)
                            {
                                int readBytes = decompressStream.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0)
                                {
                                    break;
                                }
                                writer.Write(buffer, 0, readBytes);
                            }
                        }
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
                        using (GZipStream compressStream = new GZipStream(writer, CompressionMode.Compress, false))
                        {
                            byte[] buffer = new byte[(int)partSize];
                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            compressStream.Write(buffer, 0, readBytes);
                            slicedFilesPaths.Add(destinationDir + $"Part-{i}");
                        }
                    }
                }
            }
        }
    }
}
