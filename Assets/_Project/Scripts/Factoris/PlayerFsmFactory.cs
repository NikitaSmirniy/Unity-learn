using FSMTest;

public class PlayerFsmFactory
{
    public StateMachine Create(PlayerFSMContext context)
    {
        StateMachine stateMachine = new StateMachine();

        FsmStateIdle idleState = new FsmStateIdle(stateMachine, context.Animator, context.Rigidbody);
        FsmStateWalk walkState = new FsmStateWalk(stateMachine, context.Mover, context.WalkSpeed, context.InputService, context.Animator);
        FsmStateJump jumpState = new FsmStateJump(stateMachine, context.Mover, context.JumpForce, context.InputService, context.Animator);

        Transition toIdleTransition = new ToIdleStateTransition(idleState, context.InputService, context.ObstacleCheker);
        Transition toWalkTransition = new ToWalkStateTransition(walkState, context.InputService, context.ObstacleCheker);
        Transition toJumpTransition = new ToJumpStateTransition(jumpState, context.ObstacleCheker);

        idleState.AddTransition(toJumpTransition);
        idleState.AddTransition(toWalkTransition);

        walkState.AddTransition(toIdleTransition);
        walkState.AddTransition(toJumpTransition);

        jumpState.AddTransition(toIdleTransition);
        jumpState.AddTransition(toWalkTransition);

        stateMachine.ChangeState(idleState);

        return stateMachine;
    }
}