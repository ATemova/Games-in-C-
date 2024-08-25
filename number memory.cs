using System;
using System.Threading;

class NumberMemoryGame
{
    static void Main()
    {
        Random random = new Random();
        int number = random.Next(1000, 10000);
        Console.WriteLine($"Memorize this number: {number}");
        Thread.Sleep(5000); // Wait for 5 seconds
        Console.Clear();

        Console.Write("Enter the number you memorized: ");
        int guess = int.Parse(Console.ReadLine());

        if (guess == number)
            Console.WriteLine("Correct!");
        else
            Console.WriteLine($"Wrong! The number was {number}.");
    }
}
