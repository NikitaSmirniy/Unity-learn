using System;
using UnityEngine;

public class MedKitDetector : MonoBehaviour
{
    public event Action<MedKit> Touched;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out MedKit result))
        {
            Touched?.Invoke(result);
        }
    }
}