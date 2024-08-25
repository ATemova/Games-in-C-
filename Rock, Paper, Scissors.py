using System;

class RockPaperScissors
{
    static void Main()
    {
        string[] choices = { "rock", "paper", "scissors" };
        Random random = new Random();
        string computerChoice = choices[random.Next(choices.Length)];
        
        Console.WriteLine("Enter rock, paper, or scissors:");
        string userChoice = Console.ReadLine().ToLower();

        if (!Array.Exists(choices, choice => choice == userChoice))
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Console.WriteLine($"Computer chose: {computerChoice}");

        if (userChoice == computerChoice)
            Console.WriteLine("It's a tie!");
        else if ((userChoice == "rock" && computerChoice == "scissors") ||
                 (userChoice == "paper" && computerChoice == "rock") ||
                 (userChoice == "scissors" && computerChoice == "paper"))
            Console.WriteLine("You win!");
        else
            Console.WriteLine("You lose!");
    }
}
