using System;
using UnityEngine;

public class FlagDetector : MonoBehaviour
{
    public event Action<Flag> Detected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Flag flag))
        {
            Detected?.Invoke(flag);
        }
    }
}