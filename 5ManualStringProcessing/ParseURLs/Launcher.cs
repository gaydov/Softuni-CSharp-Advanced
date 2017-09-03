using System;

namespace ParseURLs
{
    public class Launcher
    {
        public static void Main()
        {
            string url = Console.ReadLine();
            int indexOfSlash = url.IndexOf("://");
            int lastIndexOfSlash = url.LastIndexOf("://");
            if (!url.Contains("://") || !url.Contains("/") || !indexOfSlash.Equals(lastIndexOfSlash))
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                string[] urlParts = url.Split(new string[] { "://" }, StringSplitOptions.None);
                string protocol = urlParts[0];
                indexOfSlash = urlParts[1].IndexOf('/');
                if (indexOfSlash != -1)
                {
                    string server = urlParts[1].Substring(0, indexOfSlash);
                    string resources = urlParts[1].Substring(indexOfSlash + 1);

                    Console.WriteLine($"Protocol = {protocol}");
                    Console.WriteLine($"Server = {server}");
                    Console.WriteLine($"Resources = {resources}");
                }
                else
                {
                    Console.WriteLine("Invalid URL");
                }
            }
        }
    }
}
