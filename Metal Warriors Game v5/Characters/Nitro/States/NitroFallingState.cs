using Godot;
using MetalWarriorsGamev5.Utils;

namespace MetalWarriorsGamev5.Characters.Nitro.States;

public class NitroFallingState(Nitro nitro) : NitroBaseState(nitro)
{
    public override void Enter()
    {
        Nitro.Animation.Play("walking");
        Nitro.Animation.Pause();
    }

    public override string HandleState(double delta)
    {
        // Handle logic for this state

        Nitro.HandleGravity(delta);
        Nitro.HandleShooting(delta);

        // Check for needed transitions

        if (ShouldBeJetting()) return "jetting";
        if (ShouldBeIdle())    return "idle";

        return null;
    }
}
