using Godot;
using MetalWarriorsGamev5.Utils;

namespace MetalWarriorsGamev5.Characters.Nitro.States;

public class NitroWalkingState(Nitro nitro) : NitroBaseState(nitro)
{
    public override void Enter()
    {
        Nitro.Animation.Play("walking");
    }

    public override string HandleState(double delta)
    {
        // Handle logic for this state
        
        Nitro.HandleGravity(delta);
        Nitro.HandleMovement(delta);
        Nitro.HandleShooting(delta);

        // Check for needed transitions

        if (ShouldBeFalling()) return "falling";
        if (ShouldBeJetting()) return "jetting";
        if (ShouldBeIdle())    return "idle";

        return null;
    }
}
