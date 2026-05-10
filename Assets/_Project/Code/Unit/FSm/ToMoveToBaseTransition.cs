using _Project.Code;
using FSMTest;

public class ToMoveToBaseTransition : Transition
{
    private readonly Unit _unit;
        
    public ToMoveToBaseTransition(MoveToBaseState nextState, Unit unit) : base(nextState)
    {
        _unit = unit;
    }

    protected override bool CanTransit()
    {
        return _unit.IsBusy && _unit.HoldingItem;
    }
}