using System;

class DiceRoller
{
    static void Main()
    {
        Random random = new Random();
        string rollAgain;

        do
        {
            Console.WriteLine("Rolling the dice...");
            int roll = random.Next(1, 7);
            Console.WriteLine($"You rolled a {roll}!");
            Console.Write("Roll again? (yes/no): ");
            rollAgain = Console.ReadLine().ToLower();
        } while (rollAgain == "yes");
    }
}
