using System;

public interface IValueChangedPublisher
{
    event Action<int> ValueChanged;
}