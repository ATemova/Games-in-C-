using System;

class MiniSudoku
{
    static void Main()
    {
        int[,] board = {
            { 1, 0, 0, 0 },
            { 0, 0, 2, 0 },
            { 0, 0, 0, 3 },
            { 0, 4, 0, 0 }
        };

        Console.WriteLine("Mini-Sudoku 4x4");
        Console.WriteLine("Initial Board:");
        PrintBoard(board);

        if (SolveSudoku(board))
        {
            Console.WriteLine("\nSolved Board:");
            PrintBoard(board);
        }
        else
        {
            Console.WriteLine("No solution exists.");
        }
    }

    static void PrintBoard(int[,] board)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
                Console.Write(board[i, j] == 0 ? "." : board[i, j].ToString());
            Console.WriteLine();
        }
    }

    static bool SolveSudoku(int[,] board)
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (board[row, col] == 0)
                {
                    for (int num = 1; num <= 4; num++)
                    {
                        if (IsValid(board, row, col, num))
                        {
                            board[row, col] = num;
                            if (SolveSudoku(board))
                                return true;
                            board[row, col] = 0;
                        }
                    }
                    return false;
                }
            }
        }
        return true;
    }

    static bool IsValid(int[,] board, int row, int col, int num)
    {
        for (int i = 0; i < 4; i++)
            if (board[row, i] == num || board[i, col] == num)
                return false;

        int startRow = (row / 2) * 2;
        int startCol = (col / 2) * 2;
        for (int i = startRow; i < startRow + 2; i++)
            for (int j = startCol; j < startCol + 2; j++)
                if (board[i, j] == num)
                    return false;

        return true;
    }
}
