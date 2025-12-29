using System;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;

    public void Init(Health health)
    {
        _health = health;
    }

    public event Action<float> ChangedValue;

    public void TakeDamage(float damage)
    {
        _health.Value -= damage;
        ChangedValue?.Invoke(_health.Value);
    }
}