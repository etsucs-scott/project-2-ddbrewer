using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class PlayedCards
    {
        private Dictionary<string, Card> played; // Maps player names to the cards played this round

        public PlayedCards() // Makes an empty dictionary of played cards to be filled
        {
            played = new Dictionary<string, Card>();
        }

        public void AddCard(string playerName, Card card) // Adds or updates the played cards for a player in the round
        {
            played[playerName] = card;
        }

        public void Clear() // Removes all currently stored played cards
        {                   // Called before a new round so that only that rounds played cards are stored here
            played.Clear();
        }

        public Dictionary<string, Card> GetAll() // Used to move played cards into the shared pot
        {
            return played;
        }
    }
}