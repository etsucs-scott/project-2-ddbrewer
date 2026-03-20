using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class WarEngine
    {
        private PlayerHands playerHands;

        public WarEngine(List<string> playerNames)
        {
            playerHands = new PlayerHands();

            foreach (string name in playerNames)
            {
                playerHands.AddPlayer(name);
            }
        }

    public void DistributeDeck(Deck deck)
        {
            List<string> playerNames = new List<string>(playerHands.GetAllHands().Keys);

            int currentPlayer = 0;

            while (deck.Count > 0 )
            {
                Card card = deck.Draw();

                string playerName = playerNames[currentPlayer];
                playerHands.GetHand(playerName).AddCard(card);

                currentPlayer = (currentPlayer + 1) % playerNames.Count;
            }
        }

        public PlayerHands GetPlayerHands()
        {
            return playerHands;
        }
    }
}