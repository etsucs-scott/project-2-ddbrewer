using System;
using WarGame.Core;

// To sanity check: dotnet run --project src/WarGame.Console
// Anything below before project is finished is to check if x thing works

Card card1 = new Card(Suit.Hearts, Rank.Ace);
Card card2 = new Card(Suit.Spades, Rank.King);

Console.WriteLine(card1);
Console.WriteLine(card2);

Console.WriteLine(card1.CompareTo(card2));