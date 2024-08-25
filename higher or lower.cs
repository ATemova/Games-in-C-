using System;

class HigherOrLower
{
    static void Main()
    {
        Random random = new Random();
        int numberToGuess = random.Next(1, 101);
        int guess;
        int attemptsLeft = 10;

        Console.WriteLine("Try to guess the number between 1 and 100.");

        while (attemptsLeft > 0)
        {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());

            if (guess < numberToGuess)
                Console.WriteLine("Higher!");
            else if (guess > numberToGuess)
                Console.WriteLine("Lower!");
            else
            {
                Console.WriteLine("Congratulations! You've guessed the number.");
                return;
            }

            attemptsLeft--;
            Console.WriteLine($"Attempts left: {attemptsLeft}");
        }

        Console.WriteLine($"Sorry, the number was {numberToGuess}.");
    }
}
