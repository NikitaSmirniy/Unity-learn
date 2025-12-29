using FSMTest;

public class ToDeathTransition : Transition
{
    private Health _health;
    
    public ToDeathTransition(FsmState nextState, Health health) : base(nextState)
    {
        _health = health;
    }

    protected override bool CanTransit()
    {
        return _health.Value == 0;
    }
}