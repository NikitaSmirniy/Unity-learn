using FSMTest;

public class EnemyDeathState : FsmState, IEnterableState
{
    private EnemyAnimatorHandler _animator;
    
    public EnemyDeathState(IStateChanger stateChange, EnemyAnimatorHandler animator) : base(stateChange)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.PlayDeath();
    }
}