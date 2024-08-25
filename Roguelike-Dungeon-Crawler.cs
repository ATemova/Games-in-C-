using System;

class RoguelikeDungeon
{
    static int playerX = 1;
    static int playerY = 1;
    static int goalX = 8;
    static int goalY = 8;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            DrawGame();
            UpdatePlayer();
            if (playerX == goalX && playerY == goalY)
            {
                Console.WriteLine("You reached the goal!");
                break;
            }
        }
    }

    static void UpdatePlayer()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.LeftArrow) playerX--;
            if (key == ConsoleKey.RightArrow) playerX++;
            if (key == ConsoleKey.UpArrow) playerY--;
            if (key == ConsoleKey.DownArrow) playerY++;
        }
    }

    static void DrawGame()
    {
        char[,] field = new char[10, 10];

        // Initialize the field with empty spaces
        for (int y = 0; y < 10; y++)
            for (int x = 0; x < 10; x++)
                field[y, x] = '.';

        // Place the player and goal
        field[playerY, playerX] = 'P';
        field[goalY, goalX] = 'G';

        // Draw the game field
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
                Console.Write(field[y, x] + " ");
            Console.WriteLine();
        }
    }
}
