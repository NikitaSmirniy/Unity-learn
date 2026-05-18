using FSMTest;

namespace _Project.Code
{
    public class MoveToTargetState : FsmState
    {
        private Unit _unit;

        public MoveToTargetState(IStateChanger stateChange, Unit unit) : base(stateChange)
        {
            _unit = unit;
        }

        protected override void OnUpdate()
        {
            _unit.SetDestination(_unit.Target.GetPosition());
        }
    }
}