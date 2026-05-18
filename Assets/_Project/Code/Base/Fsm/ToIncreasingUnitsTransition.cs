using _Project.Code;
using FSMTest;

public class ToIncreasingUnitsTransition : Transition
{
    private readonly Base _base;

    public ToIncreasingUnitsTransition(IncreasingUnitsState nextState, Base @base) : base(nextState)
    {
        _base = @base;
    }

    protected override bool CanTransit()
    {
        return _base.Flag.IsSet == false;
    }
}