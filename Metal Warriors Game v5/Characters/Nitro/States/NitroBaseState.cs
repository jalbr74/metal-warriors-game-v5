using Godot;
using MetalWarriorsGamev5.Utils;

namespace MetalWarriorsGamev5.Characters.Nitro.States;

public abstract class NitroBaseState(Nitro nitro) : State
{
    protected readonly Nitro Nitro = nitro;

    public bool ShouldBeWalking()
    {
        if (Nitro.IsOnFloor())
        {
            return Input.GetAxis("DPadLeft", "DPadRight") != 0;
        }

        return false;
    }

    public bool ShouldBeJetting()
    {
        // if (Input.IsActionJustPressed("ButtonA") && nitro.IsOnFloor())
        // {
        //     nitro.StateMachine.TransitionTo("jetting");
        // }
        //
        return Input.IsActionPressed("ButtonB");
    }

    public bool ShouldBeFalling()
    {
        return !Nitro.IsOnFloor() && Nitro.Velocity.Y > 0;
    }
    
    public bool ShouldBeIdle()
    {
        var direction = Input.GetAxis("DPadLeft", "DPadRight");
        if (direction == 0)
        {
            if (Nitro.IsOnFloor() && Nitro.Velocity.X == 0)
            {
                return true;
            }
        }

        return false;
    }
}
