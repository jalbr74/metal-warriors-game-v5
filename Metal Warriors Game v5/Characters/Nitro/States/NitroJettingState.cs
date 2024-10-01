using Godot;
using MetalWarriorsGamev5.Utils;

namespace MetalWarriorsGamev5.Characters.Nitro.States;

public class NitroJettingState(Nitro nitro) : State
{
    public override void Enter()
    {
        nitro.Animation.Play("jetting");
    }

    public override string HandleState(double delta)
    {
        nitro.HandleGravity(delta);
        nitro.HandleMovement(delta);
        // nitro.HandleJetting(delta);

        // Check for needed transitions
        
        if (nitro.IsFalling()) return "falling";
        if (nitro.IsWalking()) return "walking";
        if (nitro.IsJetting()) return "jetting";

        return null;
    }
}
