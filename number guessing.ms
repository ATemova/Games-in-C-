using System;

class NumberGuessingGame
{
    static void Main()
    {
        Random random = new Random();
        int numberToGuess = random.Next(1, 101);
        int attemptsLeft = 10;

        Console.WriteLine("Welcome to Number Guessing Game!");
        Console.WriteLine("I'm thinking of a number between 1 and 100.");

        while (attemptsLeft > 0)
        {
            Console.Write("Enter your guess: ");
            int guess = int.Parse(Console.ReadLine());

            if (guess < numberToGuess)
                Console.WriteLine("Too low!");
            else if (guess > numberToGuess)
                Console.WriteLine("Too high!");
            else
            {
                Console.WriteLine("Congratulations! You've guessed the number.");
                return;
            }

            attemptsLeft--;
            Console.WriteLine($"Attempts left: {attemptsLeft}");
        }

        Console.WriteLine($"Sorry, you've run out of attempts. The number was {numberToGuess}.");
    }
}
