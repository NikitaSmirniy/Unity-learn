using FSMTest;

public class ToAttackState : Transition
{
    private readonly InputService _inputService;

    public ToAttackState(FsmState nextState, InputService inputService) : base(nextState)
    {
        _inputService = inputService;
    }

    protected override bool CanTransit()
    {
        return _inputService.GetIsMouseDown();
    }
}