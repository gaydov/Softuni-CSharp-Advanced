using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HTTPServer
{
    public class Launcher
    {
        private const int Port = 8181;
        private const string HtmlFilesPath = "../../pages";

        public static void Main()
        {
            IPAddress localAddress = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(localAddress, Port);
            server.Start();
            Console.WriteLine($"Waiting for a connection on {localAddress}:{Port} ... ");

            while (true)
            {
                using (NetworkStream stream = server.AcceptTcpClient().GetStream())
                {
                    byte[] request = new byte[4096];
                    int readBytes = stream.Read(request, 0, request.Length);
                    string requestDetails = Encoding.UTF8.GetString(request, 0, readBytes);
                    Console.WriteLine(requestDetails);

                    string[] requestFirstLine = requestDetails.Substring(0, requestDetails.IndexOf(Environment.NewLine)).Split();
                    string url = requestFirstLine[1];
                    string headerStatusLine = $"{requestFirstLine[2]} 200 OK";
                    string requestedPage = string.Empty;

                    if (url.Equals("/"))
                    {
                        requestedPage = $"{HtmlFilesPath}/index.html";
                    }
                    else
                    {
                        requestedPage = $"{HtmlFilesPath}{url.Substring(url.IndexOf('/'))}";

                        if (!requestedPage.EndsWith(".html"))
                        {
                            requestedPage += ".html";
                        }

                        if (!File.Exists(requestedPage))
                        {
                            requestedPage = $"{HtmlFilesPath}/error.html";
                        }
                        else
                        {
                            headerStatusLine = "HTTP/1.0 404 Not Found";
                        }
                    }

                    StringBuilder responseHeader = new StringBuilder();
                    responseHeader.Append($"{headerStatusLine}{Environment.NewLine}");
                    responseHeader.Append($"Accept-Ranges: bytes{Environment.NewLine}");

                    StringBuilder responseMessage = new StringBuilder();

                    using (StreamReader reader = new StreamReader(requestedPage))
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            responseMessage.Append(line);
                            line = reader.ReadLine();
                        }
                    }

                    if (requestedPage.EndsWith("info.html"))
                    {
                        responseMessage
                            .Replace("{0}", DateTime.Now.ToString("ddd, MMM d, yyyy"))
                            .Replace("{1}", Environment.ProcessorCount.ToString());
                    }

                    int contentLength = Encoding.UTF8.GetBytes(responseMessage.ToString()).Length;

                    responseHeader.Append($"ContentLength: {contentLength}{Environment.NewLine}");
                    responseHeader.Append($"Connection: close{Environment.NewLine}");
                    responseHeader.Append($"Content-Type: text/html{Environment.NewLine}");
                    responseHeader.Append(Environment.NewLine);

                    responseMessage.Insert(0, responseHeader);

                    byte[] responseBytes = Encoding.UTF8.GetBytes(responseMessage.ToString());

                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
        }
    }
}
