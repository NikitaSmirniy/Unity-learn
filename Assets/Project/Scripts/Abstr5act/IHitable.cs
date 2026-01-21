using System;

public interface IHitable
{
    event Action<IHitable> Hit;
}