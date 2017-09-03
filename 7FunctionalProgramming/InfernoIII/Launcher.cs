using System;
using System.Collections.Generic;
using System.Linq;

namespace InfernoIII
{
    public class Launcher
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();
            List<string> commands = new List<string>();

            // getting all commands in a list, if the command is "Reverse" we remove the last one entered
            while (!input.Equals("Forge"))
            {
                string[] args = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];
                string filterType = args[1];
                int parameter = int.Parse(args[2]);

                if (command.Equals("Exclude"))
                {
                    commands.Add(filterType + "," + parameter);
                }
                else if (command.Equals("Reverse"))
                {
                    if (commands.Contains(filterType + "," + parameter))
                    {
                        commands.Remove(filterType + "," + parameter);
                    }
                }

                input = Console.ReadLine();
            }

            // we will store the marked nums in a list
            List<int> markedNums = new List<int>();

            // applying all the commands one by one
            for (int i = 0; i < commands.Count; i++)
            {
                string[] args = commands[i].Split(',');
                string command = args[0]; // eg. "Sum Left Right"
                int param = int.Parse(args[1]); // eg. 9
                Func<int, int, bool> checkerLeftOrRight = (x, y) => x + y == param;
                Func<int, int, int, bool> checkerLeftAndRight = (x, y, z) => x + y + z == param;

                // after each command we keep the numbers that need to be marked
                List<int> numsToBeMarked = new List<int>();

                switch (command)
                {
                    case "Sum Left":

                        numsToBeMarked = SumLeft(numbers, checkerLeftOrRight);
                        break;

                    case "Sum Right":

                        numsToBeMarked = SumRight(numbers, checkerLeftOrRight);
                        break;

                    case "Sum Left Right":

                        numsToBeMarked = SumLeftRight(numbers, checkerLeftAndRight);
                        break;
                }

                // add the numbers to be marked by this command to all numbers that need to be marked
                markedNums.AddRange(numsToBeMarked);
            }

            // removing the marked numbers from the main collection
            foreach (int markedNum in markedNums)
            {
                numbers.Remove(markedNum);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> SumLeft(List<int> gems, Func<int, int, bool> checker)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < gems.Count; i++)
            {
                int leftNum;

                if (i == 0)
                {
                    leftNum = 0;
                }
                else
                {
                    leftNum = gems[i - 1];
                }

                int currentNum = gems[i];

                if (checker(leftNum, currentNum))
                {
                    result.Add(currentNum);
                }
            }

            return result;
        }

        private static List<int> SumRight(List<int> gems, Func<int, int, bool> checker)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < gems.Count; i++)
            {
                int rightNum;

                if (i == gems.Count - 1)
                {
                    rightNum = 0;
                }
                else
                {
                    rightNum = gems[i + 1];
                }

                int currentNum = gems[i];

                if (checker(currentNum, rightNum))
                {
                    result.Add(currentNum);
                }
            }

            return result;
        }

        private static List<int> SumLeftRight(List<int> gems, Func<int, int, int, bool> checker)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < gems.Count; i++)
            {
                int leftNum = 0;
                int rightNum = 0;

                if (i == 0)
                {
                    leftNum = 0;
                }
                else
                {
                    leftNum = gems[i - 1];
                }

                if (i == gems.Count - 1)
                {
                    rightNum = 0;
                }
                else
                {
                    rightNum = gems[i + 1];
                }

                int currentNum = gems[i];

                if (checker(leftNum, currentNum, rightNum))
                {
                    result.Add(currentNum);
                }
            }

            return result;
        }
    }
}
