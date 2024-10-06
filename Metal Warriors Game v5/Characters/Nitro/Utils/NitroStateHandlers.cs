using System;
using Godot;

namespace MetalWarriorsGamev5.Characters.Nitro;

public static class NitroStateHandlers
{
    public static void HandleGravity(this Nitro nitro, double delta)
    {
        if (!nitro.IsOnFloor())
        {
            nitro.Velocity += nitro.GetGravity() * (float)delta;
        }
    }
    
    public static void HandleStoppingHorizontalMovement(this Nitro nitro, double delta)
    {
        if (nitro.Velocity.X == 0) return;
        
        nitro.Velocity = new Vector2(Mathf.MoveToward(nitro.Velocity.X, 0, Nitro.Speed), nitro.Velocity.Y);
    }
    
    public static void HandleMovement(this Nitro nitro, double delta)
    {
        var direction = Input.GetAxis("DPadLeft", "DPadRight");
        if (direction == 0) return;
        
        nitro.Velocity = new Vector2(direction * Nitro.Speed, nitro.Velocity.Y);
        nitro.Animation.Scale = new Vector2(Math.Abs(nitro.Animation.Scale.X) * direction, nitro.Animation.Scale.Y);
    }
    
    public static void HandleShooting(this Nitro nitro, double delta)
    {
        if (Input.IsActionJustPressed("ButtonY"))
        {
            GD.Print("Pew!");
        }
    }

    public static void HandleJetting(this Nitro nitro, double delta)
    {
        nitro.Velocity = new Vector2(nitro.Velocity.X, Nitro.JumpVelocity);
    }

}
