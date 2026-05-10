using FSMTest;

namespace _Project.Code
{
    public class ToMoveToItemTransition : Transition
    {
        private readonly Unit _unit;
        
        public ToMoveToItemTransition(MoveToItemState nextState, Unit unit) : base(nextState)
        {
            _unit = unit;
        }

        protected override bool CanTransit()
        {
            return _unit.IsBusy && _unit.HoldingItem == null;
        }
    }
}