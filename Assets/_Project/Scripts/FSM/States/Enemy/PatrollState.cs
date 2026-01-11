using FSMTest;
using UnityEngine;

public class PatrollState : FsmStateMovement, IEnterableState
{
    protected readonly EnemyAnimatorHandler _enemyAnimatorHandler;
    protected readonly WayPointsContainer _wayPointsContainer;
    protected readonly Enemy _enemy;
    protected readonly float _acceptableSwitchingDistance;
    
    public PatrollState(IStateChanger stateChanger, Mover mover, float speed, EnemyAnimatorHandler enemyAnimatorHandler,
        WayPointsContainer wayPointsContainer, Enemy enemy,
        float acceptableSwitchingDistance) : base(
        stateChanger, mover, speed)
    {
        _enemyAnimatorHandler = enemyAnimatorHandler;
        _wayPointsContainer = wayPointsContainer;
        _enemy = enemy;
        _acceptableSwitchingDistance = acceptableSwitchingDistance;
    }
    
    private Vector2 DistanceFromNextPoint => (_wayPointsContainer.CurrentWayPoint.position - _enemy.transform.position);

    protected override void OnUpdate()
    {
        Move();

        if (HasGetTarget())
        {
            _wayPointsContainer.ChangeCurrent();
            _enemy.SetTarget(_wayPointsContainer.CurrentWayPoint);
        }
    }

    public void Move()
    {
        _mover.Move(DistanceFromNextPoint.normalized);
    }

    private bool HasGetTarget() =>
        DistanceFromNextPoint.sqrMagnitude <= _acceptableSwitchingDistance;

    public void Enter()
    {
        _enemy.SetTarget(_wayPointsContainer.CurrentWayPoint);
        _mover.SetSpeed(_speed);
        _enemyAnimatorHandler.PlayPatroll();
    }
}