using FSMTest;

public class DeathState : FsmState, IEnterableState
{
    private PlayerAnimatorHandler _animator;
    
    public DeathState(IStateChanger stateChange, PlayerAnimatorHandler animator) : base(stateChange)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.PlayDeath();
    }
}