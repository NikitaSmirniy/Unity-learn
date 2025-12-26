using FSMTest;

public class ToChaseTransition : Transition
{
    private readonly PlayerDetector _playerDetector;

    public ToChaseTransition(FsmState nextState, PlayerDetector playerDetector) : base(nextState)
    {
        _playerDetector = playerDetector;
    }

    protected override bool CanTransit()
    {
        return _playerDetector.TouchedComponent;
    }
}