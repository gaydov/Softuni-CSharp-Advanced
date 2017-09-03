using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    public class Launcher
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0];

                switch (command)
                {
                    case "1": // 1 someString - appends someString to the end of the text

                        string arg = commandArgs[1];

                        if (stack.Count == 0)
                        {
                            stack.Push(arg);
                        }
                        else
                        {
                            string lastElement = stack.Peek();
                            lastElement += arg;
                            stack.Push(lastElement);
                        }

                        break;

                    case "2": // 2 count - erases the last count elements from the text

                        arg = commandArgs[1];

                        int count = int.Parse(arg);
                        string text = stack.Peek();
                        text = text.Substring(0, text.Length - count);
                        stack.Push(text);
                        break;

                    case "3": // 3 index - returns the element at position index from the text

                        arg = commandArgs[1];

                        string currentText = stack.Peek();
                        Console.WriteLine(currentText[int.Parse(arg) - 1]);
                        break;

                    case "4": // 4 - undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation

                        stack.Pop();
                        break;
                }
            }
        }
    }
}
