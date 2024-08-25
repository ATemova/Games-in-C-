using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class TypingGame
{
    static List<string> words = new List<string>
    {
        "hello", "world", "typing", "game", "challenge"
    };

    static void Main()
    {
        Random random = new Random();
        string word = words[random.Next(words.Count)];
        Console.WriteLine("Type the following word:");
        Console.WriteLine(word);

        DateTime startTime = DateTime.Now;
        string input = Console.ReadLine();
        DateTime endTime = DateTime.Now;

        if (input == word)
        {
            Console.WriteLine("Correct! Time taken: " + (endTime - startTime).TotalSeconds + " seconds.");
        }
        else
        {
            Console.WriteLine("Incorrect. The correct word was: " + word);
        }
    }
}
