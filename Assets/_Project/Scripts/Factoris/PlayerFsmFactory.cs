using FSMTest;

public class PlayerFsmFactory
{
    public StateMachine Create(PlayerFSMContext context)
    {
        StateMachine stateMachine = new StateMachine();

        FsmStateIdle idleState = new FsmStateIdle(stateMachine, context.ObstacleCheker, context.Animator, context.Rigidbody); 
        FsmStateWalk walkState = new FsmStateWalk(stateMachine, context.InputService, context.Animator, context.Rigidbody, context.WalkSpeed); 
        FsmStateJump jumpState = new FsmStateJump(stateMachine, context.InputService, context.Animator, context.Rigidbody, context.WalkSpeed); 
        
        Transition toIdleTransition = new ToIdleStateTransition(idleState,context.InputService, context.ObstacleCheker);
        Transition toWalkTransition = new ToWalkStateTransition(walkState,context.InputService, context.ObstacleCheker);
        Transition toJumpTransition = new ToJumpStateTransition(jumpState, context.ObstacleCheker);
        
        idleState.AddTransition(toWalkTransition);
        idleState.AddTransition(toJumpTransition);
        walkState.AddTransition(toIdleTransition);
        walkState.AddTransition(toJumpTransition);
        jumpState.AddTransition(toIdleTransition);
        
        stateMachine.ChangeState(idleState);
        
        return stateMachine;
    }
}