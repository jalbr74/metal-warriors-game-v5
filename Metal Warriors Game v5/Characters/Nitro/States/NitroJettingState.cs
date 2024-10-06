using Godot;
using MetalWarriorsGamev5.Utils;

namespace MetalWarriorsGamev5.Characters.Nitro.States;

public class NitroJettingState(Nitro nitro) : NitroBaseState(nitro)
{
    public override void Enter()
    {
        // nitro.Animation.Play("jetting");
    }

    public override string HandleState(double delta)
    {
        // Handle logic for this state
        
        Nitro.HandleJetting(delta);
        Nitro.HandleMovement(delta);

        // Check for needed transitions
        
        if (ShouldBeFalling()) return "falling";
        if (ShouldBeWalking()) return "walking";

        return null;
    }
}
