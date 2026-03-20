// To sanity check: dotnet run --project src/WarGame.Console

using System;
using WarGame.Core;

class Program
{
    static void Main(string[] args)
    {
        List<string> playerNames = new List<string> { "Dakota", "Jehon", "Chris", "Leon" };

        Deck deck = new Deck();
        WarEngine game = new WarEngine(playerNames);
        game.DistributeDeck(deck);

        Console.WriteLine("After dealing the cards: ");
        Console.WriteLine("Dakota has " + game.GetPlayerHands().GetHand("Dakota").Count + " cards.");
        Console.WriteLine("Jehon has " + game.GetPlayerHands().GetHand("Jehon").Count + " cards.");
        Console.WriteLine("Chris has " + game.GetPlayerHands().GetHand("Chris").Count + " cards.");
        Console.WriteLine("Leon has " + game.GetPlayerHands().GetHand("Leon").Count + " cards.");
    }
}