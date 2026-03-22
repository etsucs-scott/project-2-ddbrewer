using System;

namespace WarGame.Core
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Rank
    {
        Two = 2, // Explicit, so everything after auto-increments
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class Card : IComparable<Card> // Implementing IComparable interface for the CompareTo() method
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString() // Returns a readable card-relevant string
        {
            return $"{Rank} of {Suit}.";
        }

        public int CompareTo(Card other) // Compares one card to another based on Rank only
        {
            if (other == null) return 1;
            return this.Rank.CompareTo(other.Rank);
        }
    }
}