using System;
using _Project.Code;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour, ITarget
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    //сделать общую коллекцию занятых items для проверки не занят ли item другой базой
    //база добавляет туда тот яйтем который взяла на сбор
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

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}