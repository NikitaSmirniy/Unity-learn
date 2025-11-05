using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected Transform _attackPoint;

    public event Action AttackHappened;

    public string Name { get; protected set; }
    public int Damage { get; protected set; }
    public float AttackDelay { get; protected set; }

    private void Start()
    {
        InitStats();
    }

    public abstract void PerformAttack();

    protected abstract void InitStats();

    protected void TriggerAttackHappened()
    {
        AttackHappened?.Invoke();
    }
}