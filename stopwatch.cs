using System;
using System.Diagnostics;

class SimpleStopwatch
{
    static void Main()
    {
        Console.WriteLine("Press Enter to start the stopwatch.");
        Console.ReadLine();
        
        Stopwatch stopwatch = Stopwatch.StartNew();
        
        Console.WriteLine("Press Enter to stop the stopwatch.");
        Console.ReadLine();
        
        stopwatch.Stop();
        Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalSeconds} seconds");
    }
}
