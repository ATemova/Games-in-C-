using System;
using System.Collections.Generic;

public class Tower
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Range { get; set; }
    public int Damage { get; set; }

    public Tower(int x, int y, int range, int damage)
    {
        X = x;
        Y = y;
        Range = range;
        Damage = damage;
    }

    public void Attack(Enemy enemy)
    {
        if (IsInRange(enemy))
        {
            enemy.Health -= Damage;
        }
    }

    private bool IsInRange(Enemy enemy)
    {
        int dx = X - enemy.X;
        int dy = Y - enemy.Y;
        return Math.Sqrt(dx * dx + dy * dy) <= Range;
    }
}

public class Enemy
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Health { get; set; }

    public Enemy(int x, int y, int health)
    {
        X = x;
        Y = y;
        Health = health;
    }
}
