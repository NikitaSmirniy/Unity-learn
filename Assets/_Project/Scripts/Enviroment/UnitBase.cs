using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class UnitBase : MonoBehaviour
{
    [field: SerializeField] public Rigidbody Rigidbody { get; protected set; }
    
    private void OnValidate()
    {
        if (this is not UnitBase)
            throw new Exception("Generic type type must match the type of the class that inherits this class");
    }
}