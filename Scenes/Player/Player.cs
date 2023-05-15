using Godot;
using System;

public class Player : KinematicBody2D
{
    

    private int speed = 250;
    private AnimatedSprite _animatedPlayerSprite;

    public override void _Ready()
    {
        _animatedPlayerSprite = GetNode<AnimatedSprite>("AnimatedSprite");
    }

    public override void _Process(float delta)
    {
        ManagerAnimationMovement();
    }

    public override void _PhysicsProcess(float delta)
    {
        Movement(delta);
    }

    private void Movement(float delta)
    {    
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Vector2 velocity = inputDirection;

        velocity = velocity.Normalized();
        velocity = MoveAndSlide(velocity * speed);
    }

    private void ManagerAnimationMovement()
    {
        if (Input.IsActionPressed("up"))
        {
            _animatedPlayerSprite.Play("walk_up");
        }
        else if (Input.IsActionPressed("down"))
        {
            _animatedPlayerSprite.Play("walk_down");
        }
        else if (Input.IsActionPressed("right"))
        {
            _animatedPlayerSprite.Play("walk_right");
        }
        else if (Input.IsActionPressed("left"))
        {
            _animatedPlayerSprite.Play("walk_left");
        }
        else
        {
            _animatedPlayerSprite.Stop();
            _animatedPlayerSprite.SetFrame(0);
        }
    }
}
