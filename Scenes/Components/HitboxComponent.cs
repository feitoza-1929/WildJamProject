using Godot;
using System;

public class HitboxComponent : Area2D
{
    [Export] public HealthComponent healthComponent;

    public override void _Ready()
    {
        healthComponent = GetNode<HealthComponent>("../HealthComponent");
    }

    public void Damage(Attack attack)
    {
        if(healthComponent != null)
        {
            healthComponent.DecrementHealth(attack.AttackDamage);
            GD.Print($"Attack Damaged {attack.AttackDamage}");
        }   
    }
}
