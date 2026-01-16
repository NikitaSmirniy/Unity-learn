using System;
using UnityEngine;

[Serializable]
public class Health : IHealthModel
{
    [SerializeField] private float _value;

    public Health(int maxValue)
    {
        MaxValue = maxValue;
        _value = MaxValue;
    }

    public float Value => _value;
    public float MaxValue { get; private set; }

    public event Action ValueChanged;

    public void Add(float value)
    {
        if (value > 0f)
        {
            _value = Mathf.Clamp(_value + value, 0f, MaxValue);
            ValueChanged?.Invoke();
        }
    }

    public void Spend(float value)
    {
        if (value > 0f)
        {
            _value = Mathf.Clamp(_value - value, 0f, MaxValue);
            ValueChanged?.Invoke();
        }
    }
}