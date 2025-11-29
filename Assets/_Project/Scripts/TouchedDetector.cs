using System;
using UnityEngine;

public class TouchedDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private bool _isTouched;

    public event Action Touched;

    private void OnCollisionEnter(Collision other)
    {
        var layer = other.gameObject.layer << 1;
        
        if (_isTouched == false && ((layer) & _layerMask) != 0)
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