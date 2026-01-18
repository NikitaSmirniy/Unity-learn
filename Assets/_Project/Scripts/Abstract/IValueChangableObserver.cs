using System;

public interface IValueChangableObserver
{
    event Action<float> ValueChanged;
}