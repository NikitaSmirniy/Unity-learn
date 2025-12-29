using FSMTest;

public class ToEnemyAttackTransition : Transition
{
    private float _acceptableSwitchingDistance;
    private Enemy _enemy;

    public ToEnemyAttackTransition(FsmState nextState, Enemy enemy, float acceptableSwitchingDistance) :
        base(nextState)
    {
        _enemy = enemy;
        _acceptableSwitchingDistance = acceptableSwitchingDistance;
    }

    protected override bool CanTransit()
    {
        return HasGetTarget();
    }

    private bool HasGetTarget() =>
        (_enemy.Target.position - _enemy.transform.position).sqrMagnitude <=
        _acceptableSwitchingDistance;
}