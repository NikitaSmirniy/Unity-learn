using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Detector<T> : MonoBehaviour
{
    public event Action<T> Detected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out T result))
            Detected?.Invoke(result);
    }
}