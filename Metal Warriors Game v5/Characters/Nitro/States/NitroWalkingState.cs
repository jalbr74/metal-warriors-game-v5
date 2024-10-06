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
        // Handle logic for this state
        
        nitro.HandleGravity(delta);
        nitro.HandleMovement(delta);
        nitro.HandleShooting(delta);

        // Check for needed transitions

        if (nitro.ShouldBeFalling()) return "falling";
        if (nitro.ShouldBeJetting()) return "jetting";
        if (nitro.ShouldBeIdle())    return "idle";

        return null;
    }
}
