using System;

public interface ICooldownTimerModel
{
    float CurrentCooldown { get; }
    float Cooldown { get; }
    
    event Action CooldownChanged;
}