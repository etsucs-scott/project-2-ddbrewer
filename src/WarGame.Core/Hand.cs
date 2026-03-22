using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class Hand
{
    private Queue<Card> cards; // Queue used for FIFO order

    public Hand() // Creates an empty hand
    {
        cards = new Queue<Card>();
    }

    public void AddCard(Card card) // Adds cards to the BACK of the hand
    {
        cards.Enqueue(card);
    }

    public Card PlayCard() // Plays cards from the TOP of the hand + throws exception if hand is empty
    {
        if (cards.Count == 0)
            throw new InvalidOperationException("No cards remaining in your hand.");
        
        return cards.Dequeue();
    }

    public int Count // Returns the number of cards in the hand
    {
        get { return cards.Count; }
    }

    public bool HasCards // Returns true if the player still has cards in their hand
    {
        get { return cards.Count > 0; }
    }
}
}