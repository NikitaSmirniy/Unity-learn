using _Project.Code;
using FSMTest;

public class ToIdleTransition : Transition
{
    private readonly Unit _unit;
        
    public ToIdleTransition(IdleState nextState, Unit unit) : base(nextState)
    {
        _unit = unit;
    }

    protected override bool CanTransit()
    {
        return _unit.IsBusy == false;
    }
}