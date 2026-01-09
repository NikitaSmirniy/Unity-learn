using FSMTest;
using UnityEngine;

public class ChaseState : FsmStateMovement, IEnterableState
{
    protected readonly EnemyAnimatorHandler _enemyAnimatorHandler;
    protected readonly Enemy _enemy;
    protected readonly float _acceptableSwitchingDistance;

    private Vector2 DistanceFromTarget => (_enemy.Target.position - _enemy.transform.position);

    public ChaseState(IStateChanger stateChanger, Mover mover, float speed, EnemyAnimatorHandler enemyAnimatorHandler,
        Enemy enemy, float acceptableSwitchingDistance) : base(stateChanger, mover, speed)
    {
        _enemyAnimatorHandler = enemyAnimatorHandler;
        _enemy = enemy;
        _acceptableSwitchingDistance = acceptableSwitchingDistance;
    }

    protected override void OnUpdate()
    {
        if (HasGetTarget())
        {
            Move();
        }
    }

    public void Move()
    {
        _mover.Move(DistanceFromTarget.normalized);
    }

    private bool HasGetTarget() =>
        DistanceFromTarget.sqrMagnitude <= _acceptableSwitchingDistance;

    public void Enter()
    {
        _enemyAnimatorHandler.PlayChase();
        _mover.SetSpeed(_speed);
    }
}