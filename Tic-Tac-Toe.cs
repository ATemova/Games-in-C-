using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char currentPlayer = 'X';

    static void Main()
    {
        int choice;
        int playerIndex;

        do
        {
            Console.Clear();
            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
            Console.WriteLine("Choose your position: ");
            choice = int.Parse(Console.ReadLine());

            // Check if move is valid
            if (choice < 1 || choice > 9 || board[choice - 1] != choice.ToString()[0])
            {
                Console.WriteLine("Invalid move, try again.");
                continue;
            }

            board[choice - 1] = currentPlayer;
            playerIndex = CheckWin();

            if (playerIndex != 0)
            {
                Console.Clear();
                Console.WriteLine("Player {0} Wins!", playerIndex);
                Console.ReadLine();
                return;
            }

            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';

        } while (true);
    }

    static int CheckWin()
    {
        // Winning combinations
        int[,] winPatterns = {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // rows
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // columns
            {0, 4, 8}, {2, 4, 6} // diagonals
        };

        for (int i = 0; i < winPatterns.GetLength(0); i++)
        {
            if (board[winPatterns[i, 0]] == board[winPatterns[i, 1]] && board[winPatterns[i, 1]] == board[winPatterns[i, 2]])
            {
                return (board[winPatterns[i, 0]] == 'X') ? 1 : 2;
            }
        }

        return 0; // No winner
    }
}
