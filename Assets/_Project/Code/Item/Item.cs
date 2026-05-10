using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    public event Action<Item> Dead;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void GetCollected()
    {
        _rigidbody.isKinematic = true;
        _collider.isTrigger = true;
    }

    public void Die()
    {
        Dead?.Invoke(this);
    }
    
    public void SetDefaultValues()
    {
        _rigidbody.isKinematic = false;
        _collider.isTrigger = false;
    }
}