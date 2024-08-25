using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1; // 1 = X, 2 = O

    static void Main()
    {
        int choice;
        int result = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("Player 1: X and Player 2: O");
            Console.WriteLine();
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
            Console.WriteLine();

            // Check for valid input
            Console.WriteLine("Player {0}, Enter your move (1-9): ", player);
            choice = int.Parse(Console.ReadLine()) - 1;

            if (choice < 0 || choice > 8 || board[choice] == 'X' || board[choice] == 'O')
            {
                Console.WriteLine("Invalid move, try again.");
                continue;
            }

            board[choice] = (player == 1) ? 'X' : 'O';

            result = CheckWin();

            player = (player == 1) ? 2 : 1;

        } while (result == 0);

        Console.Clear();
        Console.WriteLine("Player 1: X and Player 2: O");
        Console.WriteLine();
        Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        Console.WriteLine();

        if (result == 1)
            Console.WriteLine("Player {0} wins!", (player == 1) ? 2 : 1);
        else
            Console.WriteLine("It's a tie!");
    }

    static int CheckWin()
    {
        int[,] winConditions = {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Rows
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Columns
            { 0, 4, 8 }, { 2, 4, 6 } // Diagonals
        };

        foreach (var condition in winConditions)
        {
            if (board[condition[0]] == board[condition[1]] && board[condition[1]] == board[condition[2]])
                return 1;
        }

        if (Array.Exists(board, element => Char.IsDigit(element)))
            return 0; // Game is ongoing

        return -1; // Tie
    }
}
