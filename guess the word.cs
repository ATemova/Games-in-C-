using System;

class GuessTheWord
{
    static void Main()
    {
        string wordToGuess = "programming";
        char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
        int attemptsLeft = 5;

        Console.WriteLine("Guess the word!");
        
        while (attemptsLeft > 0 && new string(guessedWord).Contains('_'))
        {
            Console.WriteLine($"Current word: {new string(guessedWord)}");
            Console.Write("Guess a letter: ");
            char guess = Char.ToLower(Console.ReadLine()[0]);

            bool correctGuess = false;

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == guess)
                {
                    guessedWord[i] = guess;
                    correctGuess = true;
                }
            }

            if (!correctGuess)
            {
                attemptsLeft--;
                Console.WriteLine($"Wrong guess. Attempts left: {attemptsLeft}");
            }

            if (!new string(guessedWord).Contains('_'))
            {
                Console.WriteLine($"Congratulations! You've guessed the word: {wordToGuess}");
                return;
            }
        }

        Console.WriteLine($"Game over! The word was: {wordToGuess}");
    }
}
