

namespace TicTacToe
{
    class Player
    {
        public string Id;
        public string Marker;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my tic tac toe game!\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("You are player 1. You will be using X\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();

            var gameBoard = new List<List<string>>
            {
                new List<string> {"1", "2", "3"},
                new List<string> {"4", "5", "6"},
                new List<string> {"7", "8", "9"}
            };

            var player1 = new Player {Id = "1", Marker = "X"};
            var player2 = new Player {Id = "2", Marker = "O"};

            var currentPlayer = player1;
            var gameOver = false;
            while (!gameOver)
            {
                Console.WriteLine("This is the board\n");
                DisplayBoard(gameBoard);

                Console.WriteLine($"\nPlayer {currentPlayer.Id}. Make a move!");
                var playerChoice = Console.ReadLine();
                try
                {
                    MarkBoard(playerChoice, currentPlayer, gameBoard);

                    if (CheckForWinner(gameBoard, currentPlayer.Marker))
                    {
                        Console.Clear();
                        Console.WriteLine("This is the board\n");
                        DisplayBoard(gameBoard);
                        Console.WriteLine($"\nPlayer {currentPlayer.Id} wins!");
                        gameOver = true;
                    }
                    else if (CheckForDraw(gameBoard))
                    {
                        Console.Clear();
                        Console.WriteLine("This is the board\n");
                        DisplayBoard(gameBoard);
                        Console.WriteLine("It's a draw!");
                        gameOver = true;
                    }
                    else
                    {
                        Console.Clear();
                        currentPlayer = currentPlayer == player1 ? player2 : player1;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        static void DisplayBoard(List<List<string>> board)
        {
            foreach (var row in board)
            {
                foreach (var value in row)
                {
                    Console.Write($"|{value}|");
                }

                Console.WriteLine();
            }
        }

        static void MarkBoard(string playerChoice, Player currentPlayer, List<List<string>> gameBoard)
        {
            for (var i = 0; i < gameBoard.Count; i++)
            {
                for (var j = 0; j < gameBoard[i].Count; j++)
                {
                    if (gameBoard[i][j] == playerChoice)
                    {
                        if (gameBoard[i][j] == "X" || gameBoard[i][j] == "O")
                        {
                            throw new Exception("Spot is already taken");
                        }

                        gameBoard[i][j] = currentPlayer.Marker;
                        return;
                    }
                }
            }

            throw new Exception("Invalid choice");
        }

        static bool CheckForWinner(List<List<string>> board, string marker)
        {
            // Define all possible winning combinations
            var winningCombinations = new List<List<int>>
            {
                new List<int> {0, 1, 2}, // Top row
                new List<int> {3, 4, 5}, // Middle row
                new List<int> {6, 7, 8}, // Bottom row
                new List<int> {0, 3, 6}, // Left column
                new List<int> {1, 4, 7}, // Middle column
                new List<int> {2, 5, 8}, // Right column
                new List<int> {0, 4, 8}, // Diagonal from top-left
                new List<int> {2, 4, 6}  // Diagonal from top-right
            };

            // Check each winning combination
            foreach (var combination in winningCombinations)
            {
                if (board[combination[0] / 3][combination[0] % 3] == marker &&
                    board[combination[1] / 3][combination[1] % 3] == marker &&
                    board[combination[2] / 3][combination[2] % 3] == marker)
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheckForDraw(List<List<string>> board)
        {
            foreach (var row in board)
            {
                foreach (var value in row)
                {
                    if (value != "X" && value != "O")
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

    


