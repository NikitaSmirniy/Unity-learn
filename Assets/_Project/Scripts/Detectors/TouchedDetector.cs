using System;
using UnityEngine;

public abstract class TouchedDetector<T> : MonoBehaviour where T : MonoBehaviour 
{
    private bool _isTouched;

    public event Action Touched;
    public event Action Untouched;

    public T TouchedComponent { get; private set; }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isTouched == false && other.gameObject.TryGetComponent(out T result))
        {
            _isTouched = true;
            
            TouchedComponent = result;
            Touched?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_isTouched && other.gameObject.TryGetComponent(out T _))
        {
            SetDefault();
            
            Untouched?.Invoke();
            TouchedComponent = null;
        }
    }
    
    private void SetDefault()
    {
        _isTouched = false;
    }
}