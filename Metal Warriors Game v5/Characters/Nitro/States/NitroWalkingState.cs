using Godot;
using MetalWarriorsGamev5.Utils;

namespace MetalWarriorsGamev5.Characters.Nitro.States;

public class NitroWalkingState(Nitro nitro) : State
{
    public override void Enter()
    {
        nitro.Animation.Play("walking");
    }

    public override string HandleState(double delta)
    {
        nitro.HandleGravity(delta);
        nitro.HandleMovement(delta);
        nitro.HandleShooting(delta);
        // nitro.HandleJetting(delta);

        // Check for needed transitions
        
        if (nitro.IsFalling()) return "falling";
        if (nitro.IsJetting()) return "jetting";
        if (nitro.IsIdle()) return "idle";

        return null;
    }
}
