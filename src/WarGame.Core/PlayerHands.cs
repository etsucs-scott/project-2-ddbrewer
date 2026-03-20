using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class PlayerHands
    {
        private Dictionary<string, Hand> hands;

        public PlayerHands()
        {
            hands = new Dictionary<string, Hand>();
        }

        public void AddPlayer(string playerName)
        {
            hands[playerName] = new Hand();
        }

        public Hand GetHand(string playerName)
        {
            return hands[playerName];
        }
        
        public Dictionary<string, Hand> GetAllHands()
        {
            return hands;
        }
    }
}