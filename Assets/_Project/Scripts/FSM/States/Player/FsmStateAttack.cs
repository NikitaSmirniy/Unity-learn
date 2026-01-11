using FSMTest;

public class FsmStateAttack : FsmState, IEnterableState
{
    private readonly PlayerAnimatorHandler _playerAnimatorHandler;
    
    public FsmStateAttack(IStateChanger stateChange, PlayerAnimatorHandler playerAnimatorHandler) : base(stateChange)
    {
        _playerAnimatorHandler = playerAnimatorHandler;
    }

    public void Enter()
    {
        _playerAnimatorHandler.PlayAttack();
    }
}