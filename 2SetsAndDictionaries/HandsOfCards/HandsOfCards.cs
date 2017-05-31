using System;
using System.Collections.Generic;
using System.Linq;

namespace HandsOfCards
{
    public class HandsOfCards
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(':').ToArray();
            Dictionary<string, HashSet<string>> playerWithCards = new Dictionary<string, HashSet<string>>();

            while (!input[0].Equals("JOKER"))
            {
                string player = input[0];
                string[] cards = input[1].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (!playerWithCards.ContainsKey(player))
                {
                    playerWithCards.Add(player, new HashSet<string>(cards));
                }
                else
                {
                    playerWithCards[player].UnionWith(cards);
                }

                input = Console.ReadLine().Split(':').ToArray();
            }

            PrintScores(playerWithCards);
        }

        private static void PrintScores(Dictionary<string, HashSet<string>> playerWithCards)
        {
            foreach (KeyValuePair<string, HashSet<string>> player in playerWithCards)
            {
                int score = CalcScore(player.Value);
                Console.WriteLine($"{player.Key}: {score}");
            }
        }

        private static int CalcScore(HashSet<string> cards)
        {
            int totalScore = 0;

            foreach (string card in cards)
            {
                char type = card.Last();
                string power = card.Substring(0, card.Length - 1);

                int cardScore;
                bool isDigit = int.TryParse(power, out cardScore);

                if (!isDigit)
                {
                    switch (power)
                    {
                        case "J":
                            cardScore = 11;
                            break;

                        case "Q":
                            cardScore = 12;
                            break;

                        case "K":
                            cardScore = 13;
                            break;

                        case "A":
                            cardScore = 14;
                            break;
                    }
                }

                switch (type)
                {
                    case 'S':
                        cardScore *= 4;
                        break;

                    case 'H':
                        cardScore *= 3;
                        break;

                    case 'D':
                        cardScore *= 2;
                        break;

                    case 'C':
                        cardScore *= 1;
                        break;
                }

                totalScore += cardScore;
            }

            return totalScore;
        }
    }
}
