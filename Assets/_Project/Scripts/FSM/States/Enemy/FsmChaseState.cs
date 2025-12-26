using FSMTest;
using UnityEngine;

public class FsmChaseState : FsmStateMovement, IEnterableState
{
    protected readonly AnimatorHandler _animatorHandler;
    protected readonly Transform _transform;
    protected readonly Transform _target;
    protected readonly float _acceptableSwitchingDistance;

    public FsmChaseState(IStateChanger stateChanger, Mover mover, float speed, AnimatorHandler animatorHandler,
        Transform transform, Transform target, float acceptableSwitchingDistance) : base(stateChanger, mover, speed)
    {
        _animatorHandler = animatorHandler;
        _transform = transform;
        _target = target;
        _acceptableSwitchingDistance = acceptableSwitchingDistance;
    }

    protected override void OnUpdate()
    {
        if(HasGetTarget() == false)
            Move();
    }

    public void Move()
    {
        _mover.Move((_target.position - _transform.position).normalized);
        Debug.Log(_target);
    }

    private bool HasGetTarget() =>
        (_target.position - _transform.position).sqrMagnitude <= _acceptableSwitchingDistance;

    public void Enter()
    {
        _mover.SetSpeed(_speed);
    }
}