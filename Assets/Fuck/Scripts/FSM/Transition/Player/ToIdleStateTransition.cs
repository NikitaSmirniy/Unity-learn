using FSMTest;

public class ToIdleStateTransition : Transition
{
    private InputService _inputService;
    private ObstacleCheker _obstacleCheker;

    public ToIdleStateTransition(FsmStateIdle nextState, InputService inputService, ObstacleCheker obstacleCheker) :
        base(nextState)
    {
        _inputService = inputService;
        _obstacleCheker = obstacleCheker;
    }

    protected override bool CanTransit()
    {
        var directionOfInput = _inputService.Direction;

        bool hasInput = directionOfInput.sqrMagnitude == 0;
        bool hasObstacle = _obstacleCheker.HasObstacle(directionOfInput);

        return hasInput || hasObstacle;
    }
}