using System;
using System.Collections.Generic;

public class Unit
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Unit(string name, int health, int attackPower, int x, int y)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        X = x;
        Y = y;
    }

    public void Move(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Attack(Unit target)
    {
        target.Health -= AttackPower;
    }
}

public class RTSGame
{
    private List<Unit> units = new List<Unit>();

    public void AddUnit(Unit unit)
    {
        units.Add(unit);
    }

    public void PerformAction(Unit unit, string action, Unit target = null)
    {
        if (action == "move" && target == null)
        {
            // Example movement
            unit.Move(5, 5);
        }
        else if (action == "attack" && target != null)
        {
            unit.Attack(target);
        }
    }
}
