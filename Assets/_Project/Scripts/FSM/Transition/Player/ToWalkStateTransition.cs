using FSMTest;
using UnityEngine;

public class ToWalkStateTransition : Transition
{
    private InputService _inputService;
    private ObstacleCheker _obstacleCheker;
    
    public ToWalkStateTransition(FsmStateWalk nextState,InputService inputService, ObstacleCheker obstacleCheker) : base(nextState)
    {
        _inputService = inputService;
        _obstacleCheker = obstacleCheker;
    }

    protected override bool CanTransit()
    {
        var directionOfInput = _inputService.Direction;

        bool hasObstacle = _obstacleCheker.HasObstacle(directionOfInput);
        bool isGrounded = _obstacleCheker.IsGrounded();

        return Mathf.Approximately(directionOfInput.sqrMagnitude, 0) == false && hasObstacle == false && isGrounded;
    }
}