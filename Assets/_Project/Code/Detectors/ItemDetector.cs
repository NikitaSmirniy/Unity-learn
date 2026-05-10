using System;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public event Action<Item> Detected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            Detected?.Invoke(item);
        }
    }
}