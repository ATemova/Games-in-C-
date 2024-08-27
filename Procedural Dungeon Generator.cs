using System;
using System.Collections.Generic;

public class DungeonGenerator
{
    private static readonly Random Random = new Random();

    public static char[,] GenerateDungeon(int width, int height)
    {
        char[,] dungeon = new char[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                dungeon[x, y] = Random.Next(0, 100) < 20 ? '#' : '.'; // 20% chance of wall
            }
        }

        return dungeon;
    }

    public static void PrintDungeon(char[,] dungeon)
    {
        for (int y = 0; y < dungeon.GetLength(1); y++)
        {
            for (int x = 0; x < dungeon.GetLength(0); x++)
            {
                Console.Write(dungeon[x, y]);
            }
            Console.WriteLine();
        }
    }
}
