using Godot;
using System;

public class Events : Node
{
    [Signal] public delegate void PlayerWasAttacked(Attack attack);
    [Signal] public delegate void PlayerDied();
    [Signal] public delegate void HealthChanged(int oldHealth, int newHealth);


}
