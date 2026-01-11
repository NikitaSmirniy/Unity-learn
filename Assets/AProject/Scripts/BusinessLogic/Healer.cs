public class Healer 
{
    private int _healAmount;
    private IHealable _healable;

    public Healer(int healAmount,  IHealable healable)
    {
        _healAmount = healAmount;
        _healable = healable;
    }
    
    public void Heal()
    {
        _healable.Cure(_healAmount);
    }
}