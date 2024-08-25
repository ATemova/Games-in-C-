using System;

class ConnectFour
{
    static int[,] board = new int[6, 7];
    static int currentPlayer = 1;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            DrawBoard();
            PlayerMove();
            if (CheckWin())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Player " + currentPlayer + " wins!");
                break;
            }
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
            AITurn();
            if (CheckWin())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Player " + currentPlayer + " wins!");
                break;
            }
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
        }
    }

    static void PlayerMove()
    {
        Console.WriteLine("Player " + currentPlayer + ", choose a column (1-7): ");
        int column = int.Parse(Console.ReadLine()) - 1;
        for (int row = 5; row >= 0; row--)
        {
            if (board[row, column] == 0)
            {
                board[row, column] = currentPlayer;
                break;
            }
        }
    }

    static void AITurn()
    {
        // Simple AI: Choose the first available column
        for (int col = 0; col < 7; col++)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, col] == 0)
                {
                    board[row, col] = currentPlayer;
                    return;
                }
            }
        }
    }

    static bool CheckWin()
    {
        // Check horizontal, vertical, and diagonal wins
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (CheckDirection(row, col, 1, 0) || // Horizontal
                    CheckDirection(row, col, 0, 1) || // Vertical
                    CheckDirection(row, col, 1, 1) || // Diagonal down-right
                    CheckDirection(row, col, 1, -1))  // Diagonal down-left
                {
                    return true;
                }
            }
        }
        return false;
    }

    static bool CheckDirection(int row, int col, int deltaRow, int deltaCol)
    {
        int count = 0;
        int player = board[row, col];
        if (player == 0) return false;

        for (int i = 0; i < 4; i++)
        {
            int r = row + i * deltaRow;
            int c = col + i * deltaCol;

            if (r >= 0 && r < 6 && c >= 0 && c < 7 && board[r, c] == player)
                count++;
            else
                break;
        }
        return count == 4;
    }

    static void DrawBoard()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
                Console.Write(board[row, col] + " ");
            Console.WriteLine();
        }
    }
}
