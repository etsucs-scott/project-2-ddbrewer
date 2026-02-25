using System;

namespace WarGame.Core
{
    public class Card : IComparable<Card>
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public int CompareTo(Card other)
        {
            if (other == null) return 1;
            return this.Rank.CompareTo(other.Rank);
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}

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