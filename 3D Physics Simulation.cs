using System;

public class Particle
{
    public float X { get; set; }
    public float Y { get; set; }
    public float VelocityX { get; set; }
    public float VelocityY { get; set; }
    public float Gravity { get; set; }

    public Particle(float x, float y, float velocityX, float velocityY, float gravity)
    {
        X = x;
        Y = y;
        VelocityX = velocityX;
        VelocityY = velocityY;
        Gravity = gravity;
    }

    public void Update(float deltaTime)
    {
        VelocityY += Gravity * deltaTime;
        X += VelocityX * deltaTime;
        Y += VelocityY * deltaTime;
    }
}

public class PhysicsSimulation
{
    public static void Main()
    {
        var particle = new Particle(0, 0, 1, 10, -9.8f);
        for (int i = 0; i < 100; i++)
        {
            particle.Update(0.1f);
            Console.WriteLine($"Position: ({particle.X}, {particle.Y})");
        }
    }
}
