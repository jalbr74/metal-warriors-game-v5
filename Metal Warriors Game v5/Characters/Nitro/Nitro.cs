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
    
    public void HandleStoppingHorizontalMovement(double delta)
    {
        Velocity = new Vector2(Mathf.MoveToward(Velocity.X, 0, Speed), Velocity.Y);
    }
    
    public void HandleMovement(double delta)
    {
        var direction = Input.GetAxis("DPadLeft", "DPadRight");
        if (direction == 0) return;
        
        Velocity = new Vector2(direction * Speed, Velocity.Y);
        Animation.Scale = new Vector2(Math.Abs(Animation.Scale.X) * direction, Animation.Scale.Y);
    }
    
    public void HandleShooting(double delta)
    {
        if (Input.IsActionJustPressed("ButtonY"))
        {
            GD.Print("Pew!");
        }
    }

    public bool IsWalking()
    {
        return Input.GetAxis("DPadLeft", "DPadRight") != 0;
    }

    public bool IsJetting()
    {
        // if (Input.IsActionJustPressed("ButtonA") && nitro.IsOnFloor())
        // {
        //     nitro.StateMachine.TransitionTo("jetting");
        // }
        //
        return Input.IsActionJustPressed("ButtonB");
    }

    public bool IsFalling()
    {
        return false;
    }
    
    public bool IsIdle()
    {
        var direction = Input.GetAxis("DPadLeft", "DPadRight");
        if (direction == 0) return true;

        return false;
    }
}
