using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class WarEngine
    {
        private PlayerHands playerHands;
        private PlayedCards playedCards;
        private List<string> playerOrder; // Made for allowing un-even # of players to split extra cards to 1st in line

        public WarEngine(List<string> playerNames) // Creates game engine and makes empty hands for every player
        {
            playerHands = new PlayerHands();
            playedCards = new PlayedCards();
            playerOrder = new List<string>(playerNames);

            foreach (string name in playerNames)
            {
                playerHands.AddPlayer(name);
            }
        }

    public void DistributeDeck(Deck deck) // Deals deck in Round Robin order
        {
            List<string> playerNames = new List<string>(playerHands.GetAllHands().Keys);

            int currentPlayer = 0;

            while (deck.Count > 0 )
            {
                Card card = deck.Draw();

                string playerName = playerOrder[currentPlayer];

                playerHands.GetHand(playerName).AddCard(card);

                currentPlayer = (currentPlayer + 1) % playerOrder.Count;
            }
        }

        public PlayerHands GetPlayerHands() // Lets other parts see player hand counts
        {
            return playerHands;
        }

        private List<string> GetActivePlayers() // Returns all players with at least 1 card, so any 0 card players are "eliminated"
        {
            List<string> activePlayers = new List<string>();

            foreach (var entry in playerHands.GetAllHands())
            {
                if (entry.Value.HasCards)
                {
                    activePlayers.Add(entry.Key);
                }
            }

            return activePlayers;
        }

        private Rank GetHighestRank() // After cards are played, finds highest rank value
        {
            Rank highestRank = Rank.Two;

            foreach (var entry in playedCards.GetAll())
            {
                if (entry.Value.Rank > highestRank)
                {
                    highestRank = entry.Value.Rank;
                }
            }

            return highestRank;
        }

        private List<string> GetTiedPlayers(Rank highestRank) // Returns all plays whose card is the highest rank played, if multiple players then triggers a tiebreaker
        {
            List<string> tiedPlayers = new List<string>();

            foreach (var entry in playedCards.GetAll())
            {
                if (entry.Value.Rank == highestRank)
                {
                    tiedPlayers.Add(entry.Key);
                }
            }

            return tiedPlayers;
        }

        private void AddToPot(List<Card> pot) // Adds played cards to the pot
        {
            foreach (var entry in playedCards.GetAll())
            {
                pot.Add(entry.Value);
            }
        }

        private void AwardPotToWinner(string winner, List<Card> pot) // Gives every card in the pot to the winner, adding to the back of their hand
        {
            Hand winningHand = playerHands.GetHand(winner);

            foreach (Card card in pot)
            {
                winningHand.AddCard(card);
            }
        }

        public void PlayRound() // Utilizes everything to play one full round of the War game
        {
            List<Card> pot = new List<Card>();
            List<string> currentPlayers = GetActivePlayers();

            if (currentPlayers.Count <= 1)
            {
                return;
            }

            bool roundFinished = false;

            while (!roundFinished)
            {
                playedCards.Clear();

                List<string> playersInTie = new List<string>();

                foreach (string playerName in currentPlayers)
                {
                    Hand hand = playerHands.GetHand(playerName);

                    if (hand.HasCards)
                    {
                        Card playedCard = hand.PlayCard();
                        playedCards.AddCard(playerName, playedCard);
                        playersInTie.Add(playerName);

                        Console.WriteLine($"{playerName} plays {playedCard}.");
                    }
                    else
                    {
                        Console.WriteLine($"{playerName} is eliminated.");
                    }
                }

                if (playedCards.GetAll().Count == 0)
                {
                    Console.WriteLine("No players could continue this round.");
                    return;
                }

                AddToPot(pot);

                Rank highestRank = GetHighestRank();

                List<string> tiedPlayers = GetTiedPlayers(highestRank);

                if (tiedPlayers.Count == 1)
                {
                    string winner = tiedPlayers[0];
                    Console.WriteLine($"{winner} wins the round and takes the {pot.Count} card(s).");
                    AwardPotToWinner(winner, pot);

                    roundFinished = true;
                }
                else
                {
                    Console.WriteLine($"It's a tie! Tied players continue to a tiebreaker.");
                    currentPlayers = tiedPlayers;
                }
            }
        }

        public void PlayGame(int maxRounds) // Made to allow the looping of the game until the win conditions / round limit are met
        {
            int round = 0;

            while (CountActivePlayers() > 1 && round < maxRounds)
            {
                round++;
                Console.WriteLine($"\n===== Round {round} =====");

                PlayRound();

                foreach (var entry in playerHands.GetAllHands())
                {
                    Console.WriteLine($"{entry.Key} has {entry.Value.Count} cards.");
                }

                Console.WriteLine($"Total cards: {GetTotalCardCount()}");
            }

            Console.WriteLine($"\n===== Game Over =====");

            if (CountActivePlayers() == 1)
            {
                foreach (var entry in playerHands.GetAllHands())
                {
                    if (entry.Value.HasCards)
                    {
                        Console.WriteLine($"Winner: {entry.Key}");
                    }
                }
            }
            else
            {
                List<string> winners = GetWinner();
                int winningCount = playerHands.GetHand(winners[0]).Count;

                if (winners.Count == 1)
                {
                    Console.WriteLine($"Round limit reached. Winner by most cards is: {winners[0]} with {winningCount} cards.");
                }
                else
                {
                    Console.WriteLine($"Round limit reached. It's a draw between {string.Join(", ", winners)} with {winningCount} cards each.");
                }
            }
        }

        public int CountActivePlayers() // Keeps track of how many players have at least 1 card left
        {
            int count = 0;

            foreach (var entry in playerHands.GetAllHands())
            {
                if (entry.Value.HasCards)
                {
                    count++;
                }
            }

            return count;
        }

        public List<string> GetWinner() // Returns the player(s) with the largest hand, used when round limit is reached
        {
            List<string> winners = new List<string>();
            int highestHandCount = -1;

            foreach (var entry in playerHands.GetAllHands())
            {
                int count = entry.Value.Count;

                if (count > highestHandCount)
                {
                    highestHandCount = count;
                    winners.Clear();
                    winners.Add(entry.Key);
                }
                else if (count == highestHandCount)
                {
                    winners.Add(entry.Key);
                }
            }

            return winners;
        }

        public int GetTotalCardCount() // Returns the total number of cards across all players
        {                              // Mainly as a debugging tool to make sure cards are not lost/duplicated
            int total = 0;

            foreach (var entry in playerHands.GetAllHands())
            {
                total += entry.Value.Count;
            }

            return total;
        }
    }
}