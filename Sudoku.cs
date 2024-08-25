using System;

class SudokuSolver
{
    static int[,] board = new int[9, 9]
    {
        {5, 3, 0, 0, 7, 0, 0, 0, 0},
        {6, 0, 0, 1, 9, 5, 0, 0, 0},
        {0, 9, 8, 0, 0, 0, 0, 6, 0},
        {8, 0, 0, 0, 6, 0, 0, 0, 3},
        {4, 0, 0, 8, 0, 3, 0, 0, 1},
        {7, 0, 0, 0, 2, 0, 0, 0, 6},
        {0, 6, 0, 0, 0, 0, 2, 8, 0},
        {0, 0, 0, 4, 1, 9, 0, 0, 5},
        {0, 0, 0, 0, 8, 0, 0, 7, 9}
    };

    static void Main()
    {
        if (SolveSudoku())
            PrintBoard();
        else
            Console.WriteLine("No solution exists.");
    }

    static bool SolveSudoku()
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (board[row, col] == 0)
                {
                    for (int num = 1; num <= 9; num++)
                    {
                        if (IsValid(row, col, num))
                        {
                            board[row, col] = num;
                            if (SolveSudoku())
                                return true;
                            board[row, col] = 0; // backtrack
                        }
                    }
                    return false; // trigger backtracking
                }
            }
        }
        return true;
    }

    static bool IsValid(int row, int col, int num)
    {
        for (int x = 0; x < 9; x++)
            if (board[row, x] == num || board[x, col] == num)
                return false;

        int startRow = row - row % 3, startCol = col - col % 3;
        for (int r = 0; r < 3; r++)
            for (int d = 0; d < 3; d++)
                if (board[r + startRow, d + startCol] == num)
                    return false;

        return true;
    }

    static void PrintBoard()
    {
        for (int r = 0; r < 9; r++)
        {
            for (int d = 0; d < 9; d++)
                Console.Write(board[r, d] + " ");
            Console.WriteLine();
        }
    }
}
