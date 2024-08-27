using System;

public class VRObject
{
    public string Name { get; set; }
    public Action OnInteract { get; set; }

    public VRObject(string name, Action onInteract)
    {
        Name = name;
        OnInteract = onInteract;
    }

    public void Interact()
    {
        OnInteract?.Invoke();
    }
}

public class VRGame
{
    public static void Main()
    {
        var vrObject = new VRObject("Magic Wand", () => Console.WriteLine("You picked up the Magic Wand!"));
        vrObject.Interact();
    }
}
