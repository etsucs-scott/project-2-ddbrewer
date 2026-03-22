using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class Deck
{
    private Stack<Card> cards; // Stores cards into the deck

    public Deck() // Creates a new deck of 52 cards and shuffles it
    {
        cards = new Stack<Card>();
        InitializeDeck();
        Shuffle();
    }

    private void InitializeDeck() // Makes sure the deck gets one card of each Suit and Rank
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Push(new Card(suit, rank));
            }
        }
    }

    private void Shuffle() // Randomly shuffles the deck using Fisher-Yates algorithm (thank you Math for CS)
    {                      // NOTE: Technically converts Stack -> List, Shuffles List, Converts List -> Stack
        List<Card> tempList = new List<Card>(cards);
        cards.Clear();

        Random rng = new Random();

        for (int i = tempList.Count -1; i > 0; i--)
        {
            int j = rng.Next(i + 1);

            Card temp = tempList[i];
            tempList[i] = tempList[j];
            tempList[j] = temp;
        }

        foreach (Card card in tempList)
        {
            cards.Push(card);
        }
    }

    public Card Draw() // Draws card and returns the top card from the deck, throws exception if the deck is empty
    {
        if (cards.Count == 0)
            throw new InvalidOperationException("No cards remaining in deck.");
        
        return cards.Pop();
    }

    public int Count // Returns the # of cards remaining in the deck
    {
        get { return cards.Count; }
    }
}
}