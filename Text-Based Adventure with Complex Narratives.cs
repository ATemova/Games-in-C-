using System;
using System.Collections.Generic;

public class Room
{
    public string Description { get; set; }
    public Dictionary<string, Room> Exits { get; set; }

    public Room(string description)
    {
        Description = description;
        Exits = new Dictionary<string, Room>();
    }

    public void AddExit(string direction, Room room)
    {
        Exits[direction] = room;
    }
}

public class TextAdventureGame
{
    private Room currentRoom;

    public TextAdventureGame(Room startRoom)
    {
        currentRoom = startRoom;
    }

    public void Move(string direction)
    {
        if (currentRoom.Exits.ContainsKey(direction))
        {
            currentRoom = currentRoom.Exits[direction];
            Console.WriteLine($"Moved to: {currentRoom.Description}");
        }
        else
        {
            Console.WriteLine("You can't go that way.");
        }
    }
}
