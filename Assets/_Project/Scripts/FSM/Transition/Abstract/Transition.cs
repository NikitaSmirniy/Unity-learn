namespace FSMTest
{
    public abstract class Transition
    {
        private FsmState _nextState;

        public Transition(FsmState nextState)
        {
            _nextState = nextState;
        }

        public bool TryTransit(out FsmState nextState)
        {
            nextState = _nextState;

            return CanTransit();
        }

        protected abstract bool CanTransit();
    }
}