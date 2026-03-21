using System;
using System.Collections.Generic;
using WarGame.Core;

// To sanity check: dotnet run --project src/WarGame.Console

class Program
{
    static void Main(string[] args)
    {
        List<string> playerNames = new List<string> { "Player 1", "Player 2", "Player 3", "Player 4" };

        Deck deck = new Deck();
        WarEngine game = new WarEngine(playerNames);

        game.DistributeDeck(deck);

        game.PlayGame(10000);
    }
}