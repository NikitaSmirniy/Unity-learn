using FSMTest;

public class EnemyAttackState : FsmState, IEnterableState
{
    private readonly EnemyAnimatorHandler _enemyAnimatorHandler;

    public EnemyAttackState(IStateChanger stateChange, EnemyAnimatorHandler enemyAnimatorHandler) : base(stateChange)
    {
        _enemyAnimatorHandler = enemyAnimatorHandler;
    }

    public void Enter()
    {
        _enemyAnimatorHandler.PlayAttack();
    }
}