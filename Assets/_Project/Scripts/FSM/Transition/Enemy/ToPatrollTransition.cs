using FSMTest;

public class ToPatrollTransition : Transition
{
    private readonly PlayerDetector _playerDetector;

    public ToPatrollTransition(FsmState nextState, PlayerDetector playerDetector) : base(nextState)
    {
        _playerDetector = playerDetector;
    }

    protected override bool CanTransit()
    {
        return _playerDetector.TouchedComponent == null;
    }
}