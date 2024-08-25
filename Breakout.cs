using System;
using System.Threading;

class BreakoutGame
{
    static int ballX = 10;
    static int ballY = 5;
    static int ballVelocityX = 1;
    static int ballVelocityY = 1;

    static int paddleX = 8;
    static const int paddleY = 9;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            UpdateBall();
            DrawGame();
            Thread.Sleep(100); // Slow down the game loop for visualization
        }
    }

    static void UpdateBall()
    {
        // Move the ball
        ballX += ballVelocityX;
        ballY += ballVelocityY;

        // Bounce off the walls
        if (ballX <= 0 || ballX >= 19) ballVelocityX *= -1;
        if (ballY <= 0) ballVelocityY *= -1;

        // Bounce off the paddle
        if (ballY == paddleY - 1 && ballX >= paddleX && ballX <= paddleX + 4)
            ballVelocityY *= -1;

        // Ball falls off the screen
        if (ballY > 10)
        {
            Console.WriteLine("Game Over!");
            Environment.Exit(0);
        }

        // Paddle movement
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.LeftArrow && paddleX > 0) paddleX--;
            if (key == ConsoleKey.RightArrow && paddleX < 15) paddleX++;
        }
    }

    static void DrawGame()
    {
        char[,] field = new char[11, 20];

        // Initialize the field with empty spaces
        for (int y = 0; y < 11; y++)
            for (int x = 0; x < 20; x++)
                field[y, x] = ' ';

        // Place the paddle
        for (int i = 0; i < 5; i++)
            field[paddleY, paddleX + i] = '=';

        // Place the ball
        field[ballY, ballX] = 'O';

        // Draw the game field
        for (int y = 0; y < 11; y++)
        {
            for (int x = 0; x < 20; x++)
                Console.Write(field[y, x] + " ");
            Console.WriteLine();
        }
    }
}
