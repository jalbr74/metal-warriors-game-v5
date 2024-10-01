using Godot;
using MetalWarriorsGamev5.Utils;

namespace MetalWarriorsGamev5.Characters.Nitro.States;

public class NitroFallingState(Nitro nitro) : State
{
    public override void Enter()
    {
        nitro.Animation.Play("walking");
        nitro.Animation.Pause();
    }

    public override string HandleState(double delta)
    {
        // Handle logic for this state

        nitro.HandleGravity(delta);
        nitro.HandleShooting(delta);

        // Check for needed transitions

        if (nitro.IsJetting()) return "jetting";
        if (nitro.IsIdle())    return "idle";

        return null;
    }
}
