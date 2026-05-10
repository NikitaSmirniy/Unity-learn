public interface IEnterablePayloadState<TPayload> : IPayloadableState
{
    void Enter(TPayload payload);
}

public interface IPayloadableState
{
}