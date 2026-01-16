using System;

public interface IHealthModel
{
    float Value { get; }
    float MaxValue { get; }
    event Action ValueChanged;
}