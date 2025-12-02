using System;
using UnityEngine;

public abstract class TouchedDetector<T> : MonoBehaviour where T : MonoBehaviour 
{
    private bool _isTouched;

    public event Action<T> Touched;

    private void OnTriggerEnter(Collider other)
    {
        if (_isTouched == false && other.gameObject.TryGetComponent(out T result))
        {
            _isTouched = true;
            Touched?.Invoke(result);
        }
    }

    public void SetDefault()
    {
        _isTouched = false;
    }
}