
# CSCI 1260 — Project #2

---

# War Card Game (C#)

## Project Overview:
This project is a C#-based implementation of the car game War built using object-oriented programming design.
The program supports multiple players (tested up to 4), handles ties using a shared pot system, and runs until a winner holds all the cards or the round limit is reached (10,000).

## How to Build and Run (Command Line):
1. Open the terminal
2. Build the project: dotnet build
3. Run the program: dotnet run --project src/WarGame.Console

---

## How the War Game Works:

- A standard card deck of 52 cards is created and shuffled.
- Cards are dealt in round-robin order to all players.
- If cards do not divide evenly, the first players receive the extra cards.

- Each Round:
- All players with cards reveal their top card.
- The highest card rank wins (suits are ignored).
- If there is a tie:
- Only tied players continue to a tiebreaker round.
- Each tied player reveals another top card. This continues until no longer tied.
- All cards played in a round go into a shared pot.
- The round winner takes the entire pot.
- Players with no cards remaining are no longer able to play.

- Game Ending:
- The game ends when either one player has all 52 cards,
- Or the maximum number of rounds is reached (10,000).
- If the round limit is reached:
- The player with the most cards held wins, or
- If multiple players share the same number of cards the game is declared a draw.

## Player Setup:

- Currently the number of players is hardcoded into the Program.cs file: List<string> playerNames = new List<string> { "Player 1", "Player 2", "Player 3", "Player 4" };
- To change the number of players, add or remove names from the list of strings.

---

## Known Limitations:

- Player count is hardcoded and not based on user input (prompt or command line).

---

## Submission Note:

This project was completed as part of the CSCI 1260 course and is included in the classroom GitHub repo as required.