using System;
using UnityEngine;

public class Health
{
    private float _value;

    public event Action<float> OnHealthChanged;

    public float MaxValue { get; private set; }
    public float Value
    {
        get => _value;
        set
        {
            _value = Mathf.Clamp(value, 0f, MaxValue);
            OnHealthChanged?.Invoke(_value);
        }
    }

    public void Init(float maxValue)
    {
        MaxValue = maxValue;
        Value = MaxValue;
    }
}