using System;
using Godot;
using MetalWarriorsGamev5.Characters.Nitro.States;
using MetalWarriorsGamev5.Utils;
using MetroidvaniaGame.Characters.Player.States;

namespace MetalWarriorsGamev5.Characters.Nitro;

public partial class Nitro : CharacterBody2D
{
    public StateMachine StateMachine { get; private set; }
    public AnimatedSprite2D Animation { get; private set; }
    
    public const float Speed = 200.0f;
    public const float JumpVelocity = -400.0f;

    public override void _Ready()
    {
        Animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        
        StateMachine = new StateMachine(new System.Collections.Generic.Dictionary<string, State>
        {
            {"idle", new NitroIdleState(this)},
            {"walking", new NitroWalkingState(this)},
        });
        
        StateMachine.TransitionTo("idle");
    }

    public override void _PhysicsProcess(double delta)
    {
        StateMachine._PhysicsProcess(delta);

        MoveAndSlide();
    }

    public void HandleGravity(double delta)
    {
        if (!IsOnFloor())
        {
            Velocity += GetGravity() * (float)delta;
        }
    }
    
    public float HandleMovement(double delta)
    {
        var direction = Input.GetAxis("DPadLeft", "DPadRight");
        if (direction != 0)
        {
            Velocity = new Vector2(direction * Speed, Velocity.Y);
            
            Animation.Scale = new Vector2(Math.Abs(Animation.Scale.X) * direction, Animation.Scale.Y);
        }
        else
        {
            Velocity = new Vector2(Mathf.MoveToward(Velocity.X, 0, Speed), Velocity.Y);
        }

        return direction;
    }
}
