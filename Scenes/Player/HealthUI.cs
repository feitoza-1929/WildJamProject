using Godot;
using System;

public class HealthUI : MarginContainer
{
    private Label _healthCounter;
    private Events _events;

    public override void _Ready()
    {
        _healthCounter = GetNode<Label>("HBoxContainer/Counter");
        _events = GetNode<Events>("/root/Events");
        _events.Connect("HealthChanged", this, "OnPlayerHealthWasChanged");
    }

    private void IncrementHealthCounter(int value)
    {
        _healthCounter.Text = $"{value}";
    }

    private void DecrementHealthCounter(int value)
    {
        _healthCounter.Text = $"{value}";
    }

    private void OnPlayerHealthWasChanged(int oldHealth, int newHealth)
    {
        if(oldHealth > newHealth)
            IncrementHealthCounter(newHealth);
        else
            DecrementHealthCounter(newHealth);
    }
}
