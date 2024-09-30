using Godot;
using MetalWarriorsGamev5.Characters.Nitro;
using MetalWarriorsGamev5.Utils;

namespace MetroidvaniaGame.Characters.Player.States;

public class NitroIdleState(Nitro nitro) : State
{
    public override void Enter()
    {
        // player.Velocity = new Vector2(Mathf.MoveToward(player.Velocity.X, 0, Player.Speed), player.Velocity.Y);
        nitro.Animation.Play("walking");
        nitro.Animation.Pause();
    }

    public override void _PhysicsProcess(double delta)
    {
        nitro.HandleGravity(delta);
        nitro.HandleMovement(delta);
        // nitro.HandleJetting(delta);

        // Handle state transitions
        
        var direction = Input.GetAxis("DPadLeft", "DPadRight");
        if (direction != 0)
        {
            nitro.StateMachine.TransitionTo("walking");
            return;
        }
        
        if (Input.IsActionJustPressed("ButtonA") && nitro.IsOnFloor())
        {
            nitro.StateMachine.TransitionTo("jumping");
        }
    }
}
