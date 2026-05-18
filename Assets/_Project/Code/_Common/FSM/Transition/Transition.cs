namespace FSMTest
{
    public abstract class Transition
    {
        protected FsmState NextState;

        public Transition(FsmState nextState)
        {
            NextState = nextState;
        }

        public bool TryTransit(out FsmState nextState)
        {
            nextState = NextState;

            return CanTransit();
        }

        protected abstract bool CanTransit();
    }
}