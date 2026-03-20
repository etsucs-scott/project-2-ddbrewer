using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class Deck
{
    private Stack<Card> cards;

    public Deck()
    {
        cards = new Stack<Card>();
        InitializeDeck();
        Shuffle();
    }

    private void InitializeDeck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Push(new Card(suit, rank));
            }
        }
    }

    private void Shuffle()
    {
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

    public Card Draw()
    {
        if (cards.Count == 0)
            throw new InvalidOperationException("No cards remaining in deck.");
        
        return cards.Pop();
    }

    public int Count
    {
        get { return cards.Count; }
    }
}
}