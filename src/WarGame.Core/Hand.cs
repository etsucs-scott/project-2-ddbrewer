using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class Hand
{
    private Queue<Card> cards;

    public Hand()
    {
        cards = new Queue<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Enqueue(card);
    }

    public Card PlayCard()
    {
        if (cards.Count == 0)
            throw new InvalidOperationException("No cards remaining in your hand.");
        
        return cards.Dequeue();
    }

    public int Count
    {
        get { return cards.Count; }
    }

    public bool HasCards
    {
        get { return cards.Count > 0; }
    }
}
}