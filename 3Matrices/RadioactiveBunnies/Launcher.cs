using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveBunnies
{
    public class Launcher
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            char[][] matrix = new char[rowsCount][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            string moves = Console.ReadLine();

            for (int i = 0; i < moves.Length; i++)
            {
                char direction = moves[i];
                int currentRow = 0;
                int currentCol = 0;
                bool positionFound = false;

                // searching for the current position of the player:
                for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                {
                    if (positionFound)
                    {
                        break;
                    }

                    for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        if (matrix[rowIndex][colIndex].Equals('P'))
                        {
                            currentRow = rowIndex;
                            currentCol = colIndex;
                            positionFound = true;
                            break;
                        }
                    }
                }

                PlayerInfo currentInfo = new PlayerInfo();
                PlayerMovement(direction, matrix, currentRow, currentCol, currentInfo);
                BunniesMultiplication(matrix, currentInfo);

                // if the player has won or if he's dead we print the result:
                if (currentInfo.HasWon || currentInfo.IsDead)
                {
                    for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                    {
                        Console.WriteLine(string.Join(string.Empty, matrix[rowIndex]));
                    }

                    if (currentInfo.HasWon)
                    {
                        Console.WriteLine($"won: {currentInfo.LastLocationRow} {currentInfo.LastLocationCol}");
                        return;
                    }
                    else if (currentInfo.IsDead)
                    {
                        Console.WriteLine($"dead: {currentInfo.LastLocationRow} {currentInfo.LastLocationCol}");
                        return;
                    }
                }
            }
        }

        private static void PlayerMovement(char direction, char[][] matrix, int currentRow, int currentCol, PlayerInfo playerInfo)
        {
            int nextPosRow = 0;
            int nextPosCol = 0;

            switch (direction)
            {
                case 'L':
                    nextPosRow = currentRow;
                    nextPosCol = currentCol - 1;
                    break;

                case 'R':
                    nextPosRow = currentRow;
                    nextPosCol = currentCol + 1;
                    break;

                case 'U':
                    nextPosRow = currentRow - 1;
                    nextPosCol = currentCol;
                    break;

                case 'D':
                    nextPosRow = currentRow + 1;
                    nextPosCol = currentCol;
                    break;
            }

            // checking if the player is in the lair - if not he has won:
            if (IsPlayerInTheLair(nextPosRow, nextPosCol, matrix))
            {
                if (matrix[nextPosRow][nextPosCol].Equals('.'))
                {
                    matrix[nextPosRow][nextPosCol] = 'P';
                    matrix[currentRow][currentCol] = '.';
                }
                else if (matrix[nextPosRow][nextPosCol].Equals('B'))
                {
                    playerInfo.IsDead = true;
                    playerInfo.HasWon = false;
                    playerInfo.LastLocationRow = nextPosRow;
                    playerInfo.LastLocationCol = nextPosCol;
                }
            }
            else
            {
                playerInfo.IsDead = false;
                playerInfo.HasWon = true;
                playerInfo.LastLocationRow = currentRow;
                playerInfo.LastLocationCol = currentCol;
                matrix[playerInfo.LastLocationRow][playerInfo.LastLocationCol] = '.';
            }
        }

        private static void BunniesMultiplication(char[][] matrix, PlayerInfo playerInfo)
        {
            // getting all cells that have a bunny with their coordinates:
            List<Cell> cellsWithBunnies = new List<Cell>();

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex].Equals('B'))
                    {
                        Cell currentCell = new Cell(rowIndex, colIndex);
                        cellsWithBunnies.Add(currentCell);
                    }
                }
            }

            foreach (Cell cellsWithBunny in cellsWithBunnies)
            {
                int cellRow = cellsWithBunny.Row;
                int cellCol = cellsWithBunny.Col;

                // placing 'B' in every neighbouring cell of the current one and if there is a player we update the info object:
                if (matrix[cellRow][Math.Max(cellCol - 1, 0)].Equals('P'))
                {
                    // left

                    // if the player is already dead we should not update the info object because it already has the current information
                    if (playerInfo.IsDead == false)
                    {
                        playerInfo.IsDead = true;
                        playerInfo.HasWon = false;
                        playerInfo.LastLocationRow = cellRow;
                        playerInfo.LastLocationCol = Math.Max(cellCol - 1, 0);
                    }
                }
                else if (matrix[cellRow][Math.Min(cellCol + 1, matrix[cellRow].Length - 1)].Equals('P')) 
                {
                    // right
                    if (playerInfo.IsDead == false)
                    {
                        playerInfo.IsDead = true;
                        playerInfo.HasWon = false;
                        playerInfo.LastLocationRow = cellRow;
                        playerInfo.LastLocationCol = Math.Min(cellCol + 1, matrix[cellRow].Length - 1);
                    }
                }
                else if (matrix[Math.Max(cellRow - 1, 0)][cellCol].Equals('P')) 
                {
                    // up
                    if (playerInfo.IsDead == false)
                    {
                        playerInfo.IsDead = true;
                        playerInfo.HasWon = false;
                        playerInfo.LastLocationRow = Math.Max(cellRow - 1, 0);
                        playerInfo.LastLocationCol = cellCol;
                    }
                }
                else if (matrix[Math.Min(cellRow + 1, matrix.Length - 1)][cellCol].Equals('P')) 
                {
                    // down
                    if (playerInfo.IsDead == false)
                    {
                        playerInfo.IsDead = true;
                        playerInfo.HasWon = false;
                        playerInfo.LastLocationRow = Math.Min(cellRow + 1, matrix.Length - 1);
                        playerInfo.LastLocationCol = cellCol;
                    }
                }

                matrix[cellRow][Math.Max(cellCol - 1, 0)] = 'B'; // left
                matrix[cellRow][Math.Min(cellCol + 1, matrix[cellRow].Length - 1)] = 'B'; // right
                matrix[Math.Max(cellRow - 1, 0)][cellCol] = 'B'; // up
                matrix[Math.Min(cellRow + 1, matrix.Length - 1)][cellCol] = 'B'; // down
            }
        }

        // helper method for checking if the player is in the lair or outside:
        private static bool IsPlayerInTheLair(int nextPosRow, int nextPosCol, char[][] matrix)
        {
            if (nextPosCol < 0 || nextPosCol >= matrix[0].Length || nextPosRow < 0 || nextPosRow >= matrix.Length)
            {
                return false;
            }

            return true;
        }
    }
}
