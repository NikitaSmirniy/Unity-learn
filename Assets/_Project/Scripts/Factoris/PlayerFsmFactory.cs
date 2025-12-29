using FSMTest;

public class PlayerFsmFactory
{
    public StateMachine Create(PlayerFSMContext context)
    {
        StateMachine stateMachine = new StateMachine();

        FsmStateIdle idleState = new FsmStateIdle(stateMachine, context.PlayerAnimator, context.Rigidbody);
        FsmStateWalk walkState = new FsmStateWalk(stateMachine, context.Mover, context.WalkSpeed, context.InputService, context.PlayerAnimator);
        FsmStateJump jumpState = new FsmStateJump(stateMachine, context.Mover, context.JumpForce, context.InputService, context.PlayerAnimator);
        FsmStateAttack stateAttack = new FsmStateAttack(stateMachine, context.PlayerAnimator);
        DeathState deathState = new DeathState(stateMachine, context.PlayerAnimator);

        Transition toIdleTransition = new ToIdleStateTransition(idleState, context.InputService, context.ObstacleCheker);
        Transition toWalkTransition = new ToWalkStateTransition(walkState, context.InputService, context.ObstacleCheker);
        Transition toJumpTransition = new ToJumpStateTransition(jumpState, context.ObstacleCheker, context.InputService);
        ToAttackState toAttackState = new ToAttackState(stateAttack, context.InputService);
        ToDeathTransition toDeathState = new ToDeathTransition(deathState, context.Health);

        idleState.AddTransition(toJumpTransition);
        idleState.AddTransition(toWalkTransition);
        idleState.AddTransition(toAttackState);
        idleState.AddTransition(toDeathState);

        walkState.AddTransition(toIdleTransition);
        walkState.AddTransition(toJumpTransition);
        walkState.AddTransition(toAttackState);
        walkState.AddTransition(toDeathState);

        jumpState.AddTransition(toIdleTransition);
        jumpState.AddTransition(toWalkTransition);

        stateAttack.AddTransition(toIdleTransition);
        
        stateMachine.ChangeState(idleState);

        return stateMachine;
    }
}