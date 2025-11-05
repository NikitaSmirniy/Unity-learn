using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Money
    {
        get => Money;
        set
        {
            if (value <= 0)
                return;

            Money += value;
            AmountChanged?.Invoke();
        }
    }

    public event Action AmountChanged;

    private void OnMouseDown()
    {
        Money += 10;
    }
}