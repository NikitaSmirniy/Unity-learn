using System;

public class Wallet
{
    public int Amount { get; private set; }

    public event Action<int> ItemAmountChanged;

    public void Add(int amount)
    {
        Amount += amount;

        ItemAmountChanged?.Invoke(Amount);
    }

    public void Remove(int amount)
    {
        Amount -= amount;

        ItemAmountChanged?.Invoke(Amount);
    }
}