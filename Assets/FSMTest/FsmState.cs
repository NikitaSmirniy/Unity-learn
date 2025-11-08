namespace FSMTest
{
    public abstract class FsmState
    {
        protected readonly IFsm _fsm;

        public FsmState(IFsm fsm)
        {
            _fsm = fsm;
        }
    }
}