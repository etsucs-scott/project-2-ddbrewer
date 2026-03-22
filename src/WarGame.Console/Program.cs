using System;
using System.Collections.Generic;
using WarGame.Core;

public class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain) // Lets the user play again without re-running the program
        {
            Console.WriteLine("\nStarting War Game...\n");
            List<string> playerNames = new List<string> { "Player 1", "Player 2", "Player 3", "Player 4" };

            if (playerNames.Count < 2) // Stops the game from starting with only 1 player
                {
                    Console.WriteLine("At least two players are required to play.");
                    return;
                }

            Deck deck = new Deck();
            WarEngine game = new WarEngine(playerNames);

            game.DistributeDeck(deck);

            const int MaxRounds = 10000;
            game.PlayGame(MaxRounds);

            Console.WriteLine("\nWould you like to play again? (y/n)");
            string input = Console.ReadLine();

            if (input == null || input.ToLower() != "y") // Anything other than y exits the program
            {
                playAgain = false;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Thank you for playing.");
    }
}