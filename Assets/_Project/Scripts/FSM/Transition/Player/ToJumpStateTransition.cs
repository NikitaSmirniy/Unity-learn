using FSMTest;
using UnityEngine;

public class ToJumpStateTransition : Transition
{
    private ObstacleCheker _obstacleCheker;
    private InputService _inputService;
    
    public ToJumpStateTransition(FsmStateJump nextState, ObstacleCheker obstacleCheker, InputService inputService) : base(nextState)
    {
        _obstacleCheker = obstacleCheker;
        _inputService = inputService;
    }

    protected override bool CanTransit()
    {
        bool isGrounded = _obstacleCheker.IsGrounded();
        var isInputJump = _inputService.GetIsJump();

        return isInputJump && isGrounded;
    }
}