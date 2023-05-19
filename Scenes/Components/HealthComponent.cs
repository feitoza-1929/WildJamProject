using Godot;
using System;

public class HealthComponent : Node2D
{
    [Export]
    private int maxHealth = 3;
    private int health;
    private Events _events;

    public override void _Ready()
    {
        health = maxHealth;
        _events = GetNode<Events>("/root/Events");
    }

    public void DecrementHealth(int damage)
    {
        if(health > 0)
        {
            health = damage > health ? 0 : health - damage;
            _events.EmitSignal(
                "HealthChanged", 
                health + damage > maxHealth ? maxHealth : health + damage, 
                health);
        }
            
    
        if (health <= 0)
        {
            GD.Print($"Node {GetParent().Name} Died");
            Die();
        }
           
    
        GD.Print($"Health {health}");
    }

    public void IncrementHealth(int heal)
    {
        if (health < maxHealth && health > 0)
            health = health + heal;
    }

    public void Die() 
    {
        _events.EmitSignal("PlayerDied");
        GetParent().QueueFree();
    }
}
