using System;
using UnityEngine;

public class TouchedDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private bool _isTouched;

    public event Action Touched;

    private void OnCollisionEnter(Collision other)
    {
        if (_isTouched == false & ((1 << other.gameObject.layer) & _layerMask) != 0)
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