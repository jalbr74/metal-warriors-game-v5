using Godot;
using MetalWarriorsGamev5.Utils;

namespace MetalWarriorsGamev5.Characters.Nitro.States;

public class NitroIdleState(Nitro nitro) : NitroBaseState(nitro)
{
    public override void Enter()
    {
        Nitro.Animation.Play("walking");
        Nitro.Animation.Pause();
    }

    public override string HandleState(double delta)
    {
        // Handle logic for this state

        Nitro.HandleStoppingHorizontalMovement(delta);
        Nitro.HandleGravity(delta);
        Nitro.HandleShooting(delta);

        // Check for needed transitions

        if (ShouldBeFalling()) return "falling";
        if (ShouldBeWalking()) return "walking";
        if (ShouldBeJetting()) return "jetting";

        return null;
    }
}
