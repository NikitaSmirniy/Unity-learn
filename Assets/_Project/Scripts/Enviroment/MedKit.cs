using System;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [field: SerializeField] public int Amount { get; private set; }
    [field: SerializeField] public  AudioClip AudioClip  { get; private set; }

    public event Action<MedKit> Collected;

    public void Interact() =>
        Collected?.Invoke(this);
}