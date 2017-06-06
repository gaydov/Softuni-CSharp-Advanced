using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        public static void Main()
        {
            // The files should be put in the project's directory (e.g. D:\Softuni2\CSharp fundamentals\Streams\WordCount)

            const string wordsFilePath = "../../words.txt";
            const string textFilePath = "../../text.txt";
            const string resultFilePath = "../../results.txt";
            Dictionary<string, int> wordsCounts = new Dictionary<string, int>();
            List<string> words = new List<string>();

            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                string currentWord = wordsReader.ReadLine();
                while (currentWord != null)
                {
                    words.Add(currentWord.ToLower());
                    currentWord = wordsReader.ReadLine();
                }
            }

            using (StreamReader textReader = new StreamReader(textFilePath))
            {
                char[] delimiters = " .,-!?:;".ToCharArray();
                string line = textReader.ReadLine();

                while (line != null)
                {
                    string[] lineWords = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in words)
                    {
                        foreach (string sentenceword in lineWords)
                        {
                            if (word.ToLower().Equals(sentenceword.ToLower()))
                            {
                                if (!wordsCounts.ContainsKey(word))
                                {
                                    wordsCounts.Add(word, 1);
                                }
                                else
                                {
                                    wordsCounts[word]++;
                                }
                            }
                        }
                    }

                    line = textReader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(resultFilePath))
            {
                foreach (KeyValuePair<string, int> pair in wordsCounts.OrderByDescending(p => p.Value))
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
            Console.WriteLine("{0}Done.{0}", Environment.NewLine);
        }
    }
}
