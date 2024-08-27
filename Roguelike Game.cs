using System;
using System.Collections.Generic;

public class Room
{
    public string Description { get; set; }
    public List<string> Items { get; set; }

    public Room(string description)
    {
        Description = description;
        Items = new List<string>();
    }
}

public class RoguelikeGame
{
    private List<Room> rooms = new List<Room>();

    public void AddRoom(Room room)
    {
        rooms.Add(room);
    }

    public void DisplayRooms()
    {
        foreach (var room in rooms)
        {
            Console.WriteLine($"Room: {room.Description}");
            Console.WriteLine("Items: " + string.Join(", ", room.Items));
        }
    }
}
