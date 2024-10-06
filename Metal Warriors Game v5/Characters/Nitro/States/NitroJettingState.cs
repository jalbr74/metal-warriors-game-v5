using Godot;
using MetalWarriorsGamev5.Utils;

namespace MetalWarriorsGamev5.Characters.Nitro.States;

public class NitroJettingState(Nitro nitro) : State
{
    public override void Enter()
    {
        // nitro.Animation.Play("jetting");
    }

    public override string HandleState(double delta)
    {
        // Handle logic for this state
        
        nitro.HandleJetting(delta);
        nitro.HandleMovement(delta);

        // Check for needed transitions
        
        if (nitro.ShouldBeFalling()) return "falling";
        if (nitro.ShouldBeWalking()) return "walking";

        return null;
    }
}
