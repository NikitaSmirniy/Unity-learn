using System;

public interface IDeadObserver
{
    event Action<Cube> Dead;
}