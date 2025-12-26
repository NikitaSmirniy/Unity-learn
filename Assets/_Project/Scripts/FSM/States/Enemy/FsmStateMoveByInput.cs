using FSMTest;
using UnityEngine;

public abstract class FsmStateMoveByInput : FsmStateMovement
{
    protected readonly InputService _inputService;

    public FsmStateMoveByInput(IStateChanger stateChanger, Mover mover, float speed, InputService inputService) : base(
        stateChanger, mover, speed)
    {
        _inputService = inputService;
    }

    protected virtual void Move(Vector2 inputDirection)
    {
        _mover.Move(inputDirection);
    }
}