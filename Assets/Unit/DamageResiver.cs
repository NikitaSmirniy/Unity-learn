using UnityEngine;

public class DamageResiver
{
    private Health _health;

    public DamageResiver(Health health)
    {
        _health = health;
    }

    public void Apply(float damage)
    {
        if (damage < 0)
            return;

        var totalDamage = Process(damage);

        if (totalDamage < 0)
            return;

        _health.Value -= totalDamage;
    }

    protected virtual float Process(float damage) => damage;
}