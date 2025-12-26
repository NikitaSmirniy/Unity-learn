using FSMTest;
using UnityEngine;

public class ToJumpStateTransition : Transition
{
    private ObstacleCheker _obstacleCheker;
    
    public ToJumpStateTransition(FsmStateJump nextState, ObstacleCheker obstacleCheker) : base(nextState)
    {
        _obstacleCheker = obstacleCheker;
    }

    protected override bool CanTransit()
    {
        bool isGrounded = _obstacleCheker.IsGrounded();
        var jumpInput = Input.GetKeyDown(KeyCode.Space);

        return jumpInput && isGrounded;
    }
}