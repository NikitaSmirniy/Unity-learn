using FSMTest;

namespace _Project.Code
{
    public class ToMoveToTargetTransition : Transition
    {
        private readonly Unit _unit;
        
        public ToMoveToTargetTransition(MoveToTargetState nextState, Unit unit) : base(nextState)
        {
            _unit = unit;
        }

        protected override bool CanTransit()
        {
            return _unit.IsBusy && _unit.HoldingItem == false;
        }
    }
}