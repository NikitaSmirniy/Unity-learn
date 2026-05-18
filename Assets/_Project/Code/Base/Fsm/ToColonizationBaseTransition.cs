using _Project.Code;
using FSMTest;

public class ToColonizationBaseTransition : Transition
{
    private readonly Base _base;

    public ToColonizationBaseTransition(ColonizationBaseState nextState, Base @base) : base(nextState)
    {
        _base = @base;
    }

    protected override bool CanTransit()
    {
        return _base.Flag.IsSet;
    }
}