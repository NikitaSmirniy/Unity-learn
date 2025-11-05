namespace FSMTest
{
    public interface IFsm
    {
        void SetState<T>() where T : FsmState;
    }
}
