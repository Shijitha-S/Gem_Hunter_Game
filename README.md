The project focuses on developing the 2D game called "Gem Hunters" in which our task is to build a C# code to design a virtual game where 2 players compete to collect the
most gems within a set number of turns. The method of designing the application is as follows:

The game starts with a 6x6 game board containing 2 players (p1 and P2), some random numbers of obstacles, and random number of gems. 
In my project, I have considered 6 Obstacles and 6 gems.

The game consists of 30 rounds where players take turns.
In each turn, the current player has to enter the position to move in the board. There are 4 positions in the board siuch as U (Up), D (Down), L (Left) and R (Right).
Based on the position enetered the player wil move from current location to next position.
If there are any opstacles beside, then the players will remain in the same position as they can not move onto or through squares with obstacles.
The loop continues until the game reaches the end condition (30 moves).

Once the game ends after 30 iterations, the winner is determined based on the counts of gems the player has earned.
After 30 rounds the winner is announced or of both the players have collected same number of gems then a tie will be printed. Finally, and the game terminates.

1. Classes: The various classes used in this projects are as follows:
Position:
Represents a position on the game board with X and Y coordinates.

Player:
Represents a 3 players in the game.
This class contains  player name, current position, and gem count.
The method of this class is to move the player on the board based on input direction such as U,D,L and R.

Cell:
Represents a cell on the game board.
Contains adetails of the occupant of the cell (player, gem, obstacle, or empty).

Board:
Represents the game board.
Contains a 2D array  with 6*6 array of cells to represent the board layout.
This class initializes the board with players, gems, and obstacles.
method: 
Display(): Prints the current state of the board to the console.
IsValidMove(Player player, char direction): Checks if the move is valid.
CollectGem(Player player): Checks if the player's new position contains a gem and
updates the player's GemCoun

Game:
Controls the flow of the game.
Begins the game with a board and two players.
Manages each turns of both the players and provided final results of who has win the game or tie.
Announces the winner at the end of the game.

2. Input and Output:
Input provided the movement of the player by any of the options as U/D/L/R for up/down/left/right.
The current status of the game board will be displayed after each turn.
At the end of the game, the winner (or tie) and counts of the gem earned or collected by both players are displayed.

3. Game Rules:
Players take turns moving on the 6x6 game board.
Each player starts with 0 gems and collects gems by moving onto squares containing them until the turn reached 30 rounds.
Players cannot move onto or through squares with obstacles.
The game ends after 30 moves (15 turns for each player).
The player who have collcted most gems at the end of the game wins. If both players have the same number of gems, it's a tie.
This project provides a console-based implementation of the Gem Hunters game in C#.
The project allows players to compete to collect the most gems within a set number of turns while navigating obstacles on the game board.

**The Video demonstration of the project is attached here **
https://github.com/Shijitha-S/Gem_Hunter_Game/assets/156333057/f73e0c3c-b65d-42b2-b27a-460f42d3d3a5








