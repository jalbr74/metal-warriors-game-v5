using Godot;
using MetalWarriorsGamev5.Utils;

namespace MetalWarriorsGamev5.Characters.Nitro.States;

public class NitroIdleState(Nitro nitro) : State
{
    public override void Enter()
    {
        nitro.Animation.Play("walking");
        nitro.Animation.Pause();
    }

    public override string HandleState(double delta)
    {
        // Handle logic for this state

        nitro.HandleStoppingHorizontalMovement(delta);
        nitro.HandleGravity(delta);
        nitro.HandleShooting(delta);

        // Check for needed transitions

        if (nitro.ShouldBeFalling()) return "falling";
        if (nitro.ShouldBeWalking()) return "walking";
        if (nitro.ShouldBeJetting()) return "jetting";

        return null;
    }
}
