using System;
using UnityEngine;

[Serializable]
public class Health
{
    [ SerializeField] private float _value;

    public Health(int maxValue)
    {
        MaxValue = maxValue;
        _value = MaxValue;
    }
    
    public float Value => _value;
    public int MaxValue { get; private set; }

    public event Action ValueChanged;

    public void Add(float value)
    {
        _value = Mathf.Clamp(_value + value, 0f, MaxValue);
        ValueChanged?.Invoke();
    }

    public void Spend(float value)
    {
        _value = Mathf.Clamp(_value - value, 0f, MaxValue);
        ValueChanged?.Invoke();
    }
}