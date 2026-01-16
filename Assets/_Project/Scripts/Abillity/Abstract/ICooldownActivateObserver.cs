using System;

public interface ICooldownActivateObserver
{
    event Action CooldownStarted;
    event Action CooldownEnded;
}