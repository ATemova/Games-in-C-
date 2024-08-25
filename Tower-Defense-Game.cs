using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class TowerDefense
{
    static List<Enemy> enemies = new List<Enemy>();
    static List<Tower> towers = new List<Tower>();
    static int gameWidth = 20;
    static int gameHeight = 10;
    
    static void Main()
    {
        InitializeGame();
        while (true)
        {
            Console.Clear();
            UpdateGame();
            DrawGame();
            Thread.Sleep(500); // Slow down the game loop for visualization
        }
    }

    static void InitializeGame()
    {
        // Add towers
        towers.Add(new Tower(5, 5));
        towers.Add(new Tower(10, 5));

        // Add enemies
        enemies.Add(new Enemy(0, 1, 1));
        enemies.Add(new Enemy(0, 2, 1));
    }

    static void UpdateGame()
    {
        // Move enemies
        foreach (var enemy in enemies)
            enemy.Move();

        // Check collisions and apply tower effects
        foreach (var tower in towers)
        {
            foreach (var enemy in enemies)
            {
                if (tower.IsInRange(enemy))
                {
                    enemy.TakeDamage(tower.Damage);
                }
            }
        }

        // Remove dead enemies
        enemies = enemies.Where(e => e.Health > 0).ToList();
    }

    static void DrawGame()
    {
        char[,] field = new char[gameHeight, gameWidth];
        
        // Initialize the field with empty spaces
        for (int y = 0; y < gameHeight; y++)
            for (int x = 0; x < gameWidth; x++)
                field[y, x] = '.';

        // Place towers
        foreach (var tower in towers)
            field[tower.Y, tower.X] = 'T';

        // Place enemies
        foreach (var enemy in enemies)
            field[enemy.Y, enemy.X] = 'E';

        // Draw the game field
        for (int y = 0; y < gameHeight; y++)
        {
            for (int x = 0; x < gameWidth; x++)
                Console.Write(field[y, x] + " ");
            Console.WriteLine();
        }
    }
}

class Tower
{
    public int X { get; }
    public int Y { get; }
    public int Range { get; } = 3;
    public int Damage { get; } = 10;

    public Tower(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool IsInRange(Enemy enemy)
    {
        return Math.Abs(X - enemy.X) <= Range && Math.Abs(Y - enemy.Y) <= Range;
    }
}

class Enemy
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Health { get; private set; }
    private int speed;

    public Enemy(int x, int y, int speed)
    {
        X = x;
        Y = y;
        Health = 100;
        this.speed = speed;
    }

    public void Move()
    {
        X += speed;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
