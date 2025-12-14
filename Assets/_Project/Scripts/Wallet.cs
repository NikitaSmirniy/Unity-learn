public class Wallet
{
    public int Money { get; private set; }
    
    public void Add(int value)
    {
        if (value <= 0)
            return;

        Money += value;
    }
}