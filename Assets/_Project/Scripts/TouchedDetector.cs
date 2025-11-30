using System;
using UnityEngine;

public class TouchedDetector : MonoBehaviour
{
    private bool _isTouched;

    public event Action Touched;

    private void OnTriggerEnter(Collider other)
    {
        if (_isTouched == false && other.gameObject.TryGetComponent(out RemovalZone _))
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