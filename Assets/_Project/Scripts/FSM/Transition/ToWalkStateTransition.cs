using FSMTest;

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
        var inputDirection = _inputService.ReadInput();

        bool hasObstacle = _obstacleCheker.HasObstacle(inputDirection);
        bool isGrounded = _obstacleCheker.IsGrounded();

        return hasObstacle == false && isGrounded;
    }
}