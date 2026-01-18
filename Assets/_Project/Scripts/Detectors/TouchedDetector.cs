using System;
using UnityEngine;

public class TouchedDetector : MonoBehaviour
{
    private bool _isTouched;

    public event Action Touched;

    private void OnCollisionEnter(Collision other)
    {
        if (_isTouched == false && other.gameObject.TryGetComponent(out Ground _))
        {
            _isTouched = true;
            Touched?.Invoke();
        }
    }

    public void SetDefault()
    {
        _isTouched = false;
    }
}