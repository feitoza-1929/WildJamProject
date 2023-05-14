using Godot;
using System;

public class Player : Area2D
{
    [Signal] public delegate void PlayerIsIdle();
    [Signal] public delegate void PlayerMovedUp();
    [Signal] public delegate void PlayerMovedDown();
    [Signal] public delegate void PlayerMovedRight();
    [Signal] public delegate void PlayerMovedLeft();

    private int speed = 250;

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        EmitMovementSignal();
        Movement(delta);
    }

    private void Movement(float delta)
    {    
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Vector2 velocity = inputDirection * speed;
        Position += velocity * delta;
    }

    private void EmitMovementSignal()
    {
        if (Input.IsActionPressed("up"))
        {
            EmitSignal("PlayerMovedUp");
        }
        else if (Input.IsActionPressed("down"))
        {
            EmitSignal("PlayerMovedDown");
        }
        else if (Input.IsActionPressed("right"))
        {
            EmitSignal("PlayerMovedRight");
        }
        else if (Input.IsActionPressed("left"))
        {
            EmitSignal("PlayerMovedLeft");
        }
        else
        {
            EmitSignal("PlayerIsIdle");
        }
    }
}
