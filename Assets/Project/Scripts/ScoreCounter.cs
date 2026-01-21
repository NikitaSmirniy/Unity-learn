using System;

public class ScoreCounter : IValueChangedPublisher
{
    private HitObserver _hitObserver;
    private int _value;

    public event Action<int> ValueChanged;

    public ScoreCounter(HitObserver hitObserver)
    {
        _hitObserver = hitObserver;
        _hitObserver.Hit += Add;
    }

    public void Add(IHitable _)
    {
        _value++;
        ValueChanged?.Invoke(_value);
    }
}