using FSMTest;
using UnityEngine;

public class ToIdleStateTransition : Transition
{
    private InputService _inputService;
    private ObstacleCheker _obstacleCheker;
    
    public ToIdleStateTransition(FsmStateIdle nextState, InputService inputService, ObstacleCheker obstacleCheker) : base(nextState)
    {
        _inputService = inputService;
        _obstacleCheker = obstacleCheker;
    }

    protected override bool CanTransit()
    {
        var inputDirection = _inputService.ReadInput();
        
        bool hasInput = inputDirection.sqrMagnitude == 0;
        bool hasObstacle = _obstacleCheker.HasObstacle(inputDirection);
        
        return hasInput ||  hasObstacle;
    }
}