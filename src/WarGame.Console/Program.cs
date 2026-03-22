using System;
using System.Collections.Generic;
using WarGame.Core;

public class Program
{
    static void Main(string[] args)
    {
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

        Console.ReadLine(); // Stops the console from closing immediately after running
    }
}