using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class PlayedCards
    {
        private Dictionary<string, Card> played;

        public PlayedCards()
        {
            played = new Dictionary<string, Card>();
        }

        public void AddCard(string playerName, Card card)
        {
            played[playerName] = card;
        }

        public void Clear()
        {
            played.Clear();
        }

        public Dictionary<string, Card> GetAll()
        {
            return played;
        }
    }
}