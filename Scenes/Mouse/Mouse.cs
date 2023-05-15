using Godot;
using System;

public class Mouse : Node2D
{
    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Hidden;
    }

    public override void _Process(float delta)
    {
        GlobalPosition = GetViewport().GetMousePosition();
    }

}
