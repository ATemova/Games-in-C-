using System;
using System.Threading;

class PlatformerGame
{
    static int playerX = 5;
    static int playerY = 0;
    static int playerVelocityY = 0;
    static bool isJumping = false;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            UpdatePlayer();
            DrawGame();
            Thread.Sleep(100); // Slow down the game loop for visualization
        }
    }

    static void UpdatePlayer()
    {
        // Simple gravity
        if (playerY < 10)
        {
            playerVelocityY += 1; // Gravity effect
        }
        else
        {
            playerVelocityY = 0;
            playerY = 10;
        }

        // Apply velocity
        playerY += playerVelocityY;

        // Simple input handling
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.LeftArrow) playerX--;
            if (key == ConsoleKey.RightArrow) playerX++;
            if (key == ConsoleKey.Spacebar && playerY == 10) // Jump only if on the ground
            {
                playerVelocityY = -5; // Jump force
                isJumping = true;
            }
        }
    }

    static void DrawGame()
    {
        char[,] field = new char[11, 20];

        // Initialize the field with empty spaces and ground
        for (int y = 0; y < 11; y++)
            for (int x = 0; x < 20; x++)
                field[y, x] = y == 10 ? '-' : ' ';

        // Place the player
        field[playerY, playerX] = 'P';

        // Draw the game field
        for (int y = 0; y < 11; y++)
        {
            for (int x = 0; x < 20; x++)
                Console.Write(field[y, x] + " ");
            Console.WriteLine();
        }
    }
}
