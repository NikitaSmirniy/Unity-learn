using System;

public class HitObserver : IDisposable
{
    private IHitPublisher _hitPublisher;
    
    public event Action<IHitable> Hit;

    public HitObserver(IHitPublisher hitPublisher)
    {
        _hitPublisher = hitPublisher;
        _hitPublisher.Hit += OnHit;
    }

    public void Dispose()
    {
        if (_hitPublisher != null)
            _hitPublisher.Hit -= OnHit;
    }

    private void OnHit(IHitable hitable)
    {
        Hit?.Invoke(hitable);
    }
}