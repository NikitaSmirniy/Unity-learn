using System;
using UnityEngine;

public class CoinsDetector : MonoBehaviour
{
    public event Action<Coin> Touched;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin result))
        {
            Touched?.Invoke(result);
        }
    }
}