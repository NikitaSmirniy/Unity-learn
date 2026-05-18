using _Project.Code;
using FSMTest;

public class ToBuildingBaseTransition : Transition
{
    private readonly Unit _unit;

    public ToBuildingBaseTransition(BuildingBaseState nextState, Unit unit) : base(nextState)
    {
        _unit = unit;
    }

    protected override bool CanTransit()
    {
        return _unit.IsBuilding;
    }
}