using System;

class MazeSolver
{
    static int[,] maze = {
        {1, 0, 0, 0, 0, 0},
        {1, 1, 0, 1, 1, 1},
        {0, 1, 0, 1, 0, 0},
        {0, 1, 0, 1, 0, 1},
        {0, 1, 1, 1, 0, 1},
        {0, 0, 0, 0, 0, 1}
    };

    static bool[,] visited = new bool[6, 6];
    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };

    static void Main()
    {
        if (SolveMaze(0, 0))
            PrintMaze();
        else
            Console.WriteLine("No solution found.");
    }

    static bool SolveMaze(int x, int y)
    {
        if (x == 5 && y == 5)
            return true;

        if (IsValid(x, y))
        {
            visited[x, y] = true;

            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                if (SolveMaze(newX, newY))
                    return true;
            }
        }

        return false;
    }

    static bool IsValid(int x, int y)
    {
        return (x >= 0 && x < 6 && y >= 0 && y < 6 && maze[x, y] == 1 && !visited[x, y]);
    }

    static void PrintMaze()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
                Console.Write((visited[i, j] ? "1 " : "0 "));
            Console.WriteLine();
        }
    }
}
