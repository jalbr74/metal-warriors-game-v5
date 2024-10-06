using System;
using Godot;
using MetalWarriorsGamev5.Characters.Nitro.States;
using MetalWarriorsGamev5.Utils;

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
            {"jetting", new NitroJettingState(this)},
            {"falling", new NitroFallingState(this)},
        });
        
        StateMachine.TransitionTo("idle");
    }

    public override void _PhysicsProcess(double delta)
    {
        StateMachine._PhysicsProcess(delta);

        MoveAndSlide();
    }
}
