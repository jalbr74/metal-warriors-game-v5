using Godot;

namespace MetalWarriorsGamev5.Characters.Nitro;

public static class NitroStateReaders
{
    public static bool ShouldBeWalking(this Nitro nitro)
    {
        if (nitro.IsOnFloor())
        {
            return Input.GetAxis("DPadLeft", "DPadRight") != 0;
        }

        return false;
    }

    public static bool ShouldBeJetting(this Nitro nitro)
    {
        // if (Input.IsActionJustPressed("ButtonA") && nitro.IsOnFloor())
        // {
        //     nitro.StateMachine.TransitionTo("jetting");
        // }
        //
        return Input.IsActionPressed("ButtonB");
    }

    public static bool ShouldBeFalling(this Nitro nitro)
    {
        return !nitro.IsOnFloor() && nitro.Velocity.Y > 0;
    }
    
    public static bool ShouldBeIdle(this Nitro nitro)
    {
        var direction = Input.GetAxis("DPadLeft", "DPadRight");
        if (direction == 0)
        {
            if (nitro.IsOnFloor() && nitro.Velocity.X == 0)
            {
                return true;
            }
        }

        return false;
    }
}
