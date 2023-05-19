using Godot;
using System;

public class Attack
{
    public int AttackDamage;
    public float StunTime;

    public Attack(int attackDamage, float stunTime)
    {
        AttackDamage = attackDamage;
        StunTime = stunTime;
    }
}
