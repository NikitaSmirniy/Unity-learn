using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [field: SerializeField] public int Amount { get; private set; }
    [field: SerializeField] public  AudioClip AudioClip  { get; private set; }

    public event Action<Coin> Collected;

    public void Interact() =>
        Collected?.Invoke(this);
}