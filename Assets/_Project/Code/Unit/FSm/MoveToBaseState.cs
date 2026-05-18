using _Project.Code;
using FSMTest;
using UnityEngine;

public class MoveToBaseState : FsmState
{
    private readonly Unit _unit;

    public MoveToBaseState(IStateChanger stateChange, Unit unit) : base(stateChange)
    {
        _unit = unit;
    }

    protected override void OnUpdate()
    {
        _unit.SetDestination(_unit.BaseTransform.position);
    }
}