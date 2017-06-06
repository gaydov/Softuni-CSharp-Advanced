using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    public class DirectoryTraversal
    {
        public static void Main()
        {
            Console.Write("Directory to be listed: ");
            string dirToBeListed = Console.ReadLine();
            DirectoryInfo dirInfo = new DirectoryInfo(dirToBeListed);
            List<string> errors = new List<string>(); // list that will keep errors that occured
            Dictionary<string, List<FileInfo>> extensionsAndFiles = new Dictionary<string, List<FileInfo>>();
            GetExtensionsAndFiles(dirInfo, errors, extensionsAndFiles);

            string desktopPathReportFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";

            if (File.Exists(desktopPathReportFile))
            {
                FileInfo reportFileInfo = new FileInfo(desktopPathReportFile);
                if (reportFileInfo.Length != 0)
                {
                    Console.Write("{0}The report file already exists. Do you want to overwrite it?{0}Enter Y or N: ", Environment.NewLine);
                    if (Console.ReadLine().ToUpper().Equals("N"))
                    {
                        Console.WriteLine("{0}The request was canceled.{0}", Environment.NewLine);
                        return;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(desktopPathReportFile))
            {
                foreach (KeyValuePair<string, List<FileInfo>> extension in extensionsAndFiles.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
                {
                    writer.WriteLine(extension.Key);

                    foreach (FileInfo file in extension.Value.OrderBy(f => f.Length))
                    {
                        writer.WriteLine($"--{file.Name} - {file.Length / 1024}kb");
                    }
                }
            }
            Console.WriteLine("{0}Done. The report is on your desktop.{0}", Environment.NewLine);
        }

        public static void GetExtensionsAndFiles(DirectoryInfo dirToBeListed, List<string> errors, Dictionary<string, List<FileInfo>> extensionsAndFiles)
        {
            FileInfo[] files = null;

            try
            {
                files = dirToBeListed.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException unauthorizedException)
            {
                errors.Add(unauthorizedException.Message);
            }

            catch (DirectoryNotFoundException dirNotFoundException)
            {
                Console.WriteLine(dirNotFoundException.Message);
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    string currentFileExt = Path.GetExtension(fi.FullName);
                    if (!extensionsAndFiles.ContainsKey(currentFileExt))
                    {
                        extensionsAndFiles.Add(currentFileExt, new List<FileInfo>());
                        extensionsAndFiles[currentFileExt].Add(fi);
                    }
                    else
                    {
                        extensionsAndFiles[currentFileExt].Add(fi);
                    }
                }
            }
        }
    }
}
