using System;

public interface IHitPublisher
{
    event Action<IHitable> Hit;
}