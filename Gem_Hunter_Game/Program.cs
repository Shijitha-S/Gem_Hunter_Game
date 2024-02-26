using System;

public class Position
{
    public int X { get; }
    public int Y { get; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Player
{
    public string Name { get; }
    public Position Position { get; set; }
    public int GemCount { get; set; }

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
        GemCount = 0;
    }

    public void Move(char direction)
    {
        switch (direction)
        {
            case 'U':
                Position = new Position(Position.X, Position.Y - 1);
                break;
            case 'D':
                Position = new Position(Position.X, Position.Y + 1);
                break;
            case 'L':
                Position = new Position(Position.X - 1, Position.Y);
                break;
            case 'R':
                Position = new Position(Position.X + 1, Position.Y);
                break;
        }
    }
}

public class Cell
{
    public string Occupant { get; set; }

    public Cell(string occupant)
    {
        Occupant = occupant;
    }
}

public class Board
{
    private readonly Cell[,] Grid;

    public Board()
    {
        Grid = new Cell[6, 6];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        // All cells as empty intially
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Grid[i, j] = new Cell("-");
            }
        }

        //Rrandomly place 6 obstacles
        Random rand = new Random();
        for (int i = 0; i < 6; i++)
        {
            int x = rand.Next(6);
            int y = rand.Next(6);
            Grid[x, y] = new Cell("O");
        }

        // Set players as P1 and P2
        Grid[0, 0].Occupant = "P1";
        Grid[5, 5].Occupant = "P2";

        // Randomly place 6 gems
        for (int i = 0; i < 6; i++)
        {
            int x = rand.Next(6);
            int y = rand.Next(6);
            if (Grid[x, y].Occupant == "-")
            {
                Grid[x, y].Occupant = "G";
            }
            else
            {
                i--; 
            }
        }
    }

    public void Display()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.Write(Grid[i, j].Occupant + " ");
            }
            Console.WriteLine();
        }
    }

    public bool IsValidMove(Player player, char direction)
    {
        int newX = player.Position.X;
        int newY = player.Position.Y;

        switch (direction)
        {
            case 'U':
                newY--;
                break;
            case 'D':
                newY++;
                break;
            case 'L':
                newX--;
                break;
            case 'R':
                newX++;
                break;
        }

        if (newX < 0 || newX >= 6 || newY < 0 || newY >= 6)
        {
            return false; // Out of bounds
        }

        // Check if the current position contains an obstacle
        if (Grid[newY, newX].Occupant == "O")
        {
            return false; // Obstacle
        }

        return true;
    }

    public void MovePlayer(Player player, char direction)
    {
        if (IsValidMove(player, direction))
        {
            int newX = player.Position.X;
            int newY = player.Position.Y;

            switch (direction)
            {
                case 'U':
                    newY--;
                    break;
                case 'D':
                    newY++;
                    break;
                case 'L':
                    newX--;
                    break;
                case 'R':
                    newX++;
                    break;
            }

            // verify if current position contains a gem
            if (Grid[newY, newX].Occupant == "G")
            {
                player.GemCount++;
                Grid[newY, newX].Occupant = "-"; // Add the gem to the Player
            }

            
            Grid[player.Position.Y, player.Position.X].Occupant = "-";
            Grid[newY, newX].Occupant = player.Name;

            // Update the player's position
            player.Position = new Position(newX, newY);
        }
    }
}

public class Game
{
    private readonly Board Board;
    private readonly Player Player1;
    private readonly Player Player2;
    private Player CurrentTurn;
    private int TotalTurns;

    public Game()
    {
        Board = new Board();
        Player1 = new Player("P1", new Position(0, 0));
        Player2 = new Player("P2", new Position(5, 5));
        CurrentTurn = Player1;
        TotalTurns = 0;
    }

    public void Start()
    {
        while (!IsGameOver())
        {
            Board.Display();
            Console.WriteLine($"Current Turn: {CurrentTurn.Name}");
            Console.Write("Enter move (U/D/L/R): ");
            char move = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            if (move == 'U' || move == 'D' || move == 'L' || move == 'R')
            {
                Board.MovePlayer(CurrentTurn, move);
                TotalTurns++;
                SwitchTurn();
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
        AnnounceWinner();
    }

    private void SwitchTurn()
    {
        CurrentTurn = (CurrentTurn == Player1) ? Player2 : Player1;
    }

    private bool IsGameOver()
    {
        return TotalTurns >= 30;
    }

    private void AnnounceWinner()
    {
        Console.WriteLine("Game over!");
        Console.WriteLine($"Player 1 Gems: {Player1.GemCount}");
        Console.WriteLine($"Player 2 Gems: {Player2.GemCount}");
        if (Player1.GemCount > Player2.GemCount)
        {
            Console.WriteLine("Player 1 wins!");
        }
        else if (Player2.GemCount > Player1.GemCount)
        {
            Console.WriteLine("Player 2 wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}
