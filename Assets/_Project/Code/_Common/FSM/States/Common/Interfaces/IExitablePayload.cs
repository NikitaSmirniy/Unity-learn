namespace FSMTest
{
    public interface IExitablePayloadState<TPayload> : IPayloadableState
    {
        void Exit(TPayload payload);
    }
}