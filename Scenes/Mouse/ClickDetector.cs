using Godot;
using System;

public class ClickDetector : Area2D
{
    private bool isMouseOver;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && isMouseOver)
        {
            var parentNode = GetParent();
            GD.Print(parentNode.Name);

            switch (mouseEvent.ButtonIndex)
            {
                case (int)ButtonList.Left:
                    GD.Print($"Left button was clicked at {mouseEvent.Position}");
                    break;
            }
        }
    }

    private void OnClickDetectorMouseEntered()
    {
        isMouseOver = true;
        GD.Print($"IsMouseOver {isMouseOver}");
    }

    private void OnClickDetectorMouseExited()
    {
        isMouseOver = true;
        GD.Print($"IsMouseOver {isMouseOver}");
    }
}
