using Godot;
using System;

public class AnimatedSprite : Godot.AnimatedSprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var player = GetParent<Area2D>();

        player.Connect("PlayerIsIdle", this, nameof(OnPlayerIsIdle));
        player.Connect("PlayerMovedUp", this, nameof(OnPlayerMovedUp));
        player.Connect("PlayerMovedDown", this, nameof(OnPlayerMovedDown));
        player.Connect("PlayerMovedRight", this, nameof(OnPlayerMovedRight));
        player.Connect("PlayerMovedLeft", this, nameof(OnPlayerMovedLeft));
    }

    private void OnPlayerIsIdle()
    {
        Stop();
    }

    private void OnPlayerMovedRight()
    {
        Play("run");
        FlipH = false;
    }

    private void OnPlayerMovedLeft()
    {
        Play("run");
        FlipH = true;
    }

    private void OnPlayerMovedDown()
    {
        Play("run");
    }

    private void OnPlayerMovedUp()
    {
        Play("run");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }


}
