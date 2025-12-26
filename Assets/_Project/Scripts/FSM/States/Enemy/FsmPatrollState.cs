using FSMTest;
using UnityEngine;

public class FsmPatrollState : FsmStateMovement, IEnterableState
{
    protected readonly AnimatorHandler _animatorHandler;
    protected readonly WayPointsContainer _wayPointsContainer;
    protected readonly Transform _transform;
    protected readonly float _acceptableSwitchingDistance;

    public FsmPatrollState(IStateChanger stateChanger, Mover mover, float speed, AnimatorHandler animator,
        WayPointsContainer wayPointsContainer, Transform transform,
        float acceptableSwitchingDistance) : base(
        stateChanger, mover, speed)
    {
        _animatorHandler = animator;
        _wayPointsContainer = wayPointsContainer;
        _transform = transform;
        _acceptableSwitchingDistance = acceptableSwitchingDistance;
    }

    protected override void OnUpdate()
    {
        Move();

        if (HasGetTarget())
        {
            _wayPointsContainer.ChangeCurrent();
            _mover.SetTarget(_wayPointsContainer.CurrentWayPoint.position);
        }
    }

    public void Move()
    {
        _mover.Move((_wayPointsContainer.CurrentWayPoint.position - _transform.position).normalized);
    }

    private bool HasGetTarget() =>
        (_wayPointsContainer.CurrentWayPoint.position - _transform.position).sqrMagnitude <= _acceptableSwitchingDistance;

    public void Enter()
    {
        _mover.SetSpeed(_speed);
    }
}