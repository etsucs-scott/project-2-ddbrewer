using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class PlayerHands
    {
        private Dictionary<string, Hand> hands; // Maps player names to their corresponding hand

        public PlayerHands() // Makes an empty collection of player hands
        {
            hands = new Dictionary<string, Hand>();
        }

        public void AddPlayer(string playerName) // Adds a new player to the game and creates a hand for them
        {                                        // NOTE: If same name is used, hand will be overwritten
            hands[playerName] = new Hand();
        }

        public Hand GetHand(string playerName) // Mainly to allow WarEngine to manipulate player hands
        {
            return hands[playerName];
        }
        
        public Dictionary<string, Hand> GetAllHands() // Returns full dictionary of all player hands
        {                                             // Mainly for looping through players and finding a winner
            return hands;
        }
    }
}