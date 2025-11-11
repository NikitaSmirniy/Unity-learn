using UnityEngine;

public abstract class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] protected string _name;
    [SerializeField, Min(0)] protected int _damage;
    [SerializeField, Min(0)] protected float _attackDelay;
    [SerializeField] protected LayerMask _layerMask;

    public string Name => _name;
    public int Damage => _damage;
    public float AttackDelay => _attackDelay;
    public LayerMask LayerMask => _layerMask;
}