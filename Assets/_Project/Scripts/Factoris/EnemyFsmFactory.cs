using FSMTest;

public class EnemyFsmFactory
{
    public StateMachine Create(EnemyFsmContext context)
    {
        StateMachine stateMachine = new StateMachine();

        FsmPatrollState patrolState = new FsmPatrollState(stateMachine, context.Mover, context.Speed,
            context.AnimatorHandler, context.WayPointsContainer, context.EnemyTransform,
            context.AcceptableSwitchingDistance);

        FsmChaseState chaseState = new FsmChaseState(stateMachine, context.Mover, context.Speed,
            context.AnimatorHandler, context.EnemyTransform, context.Target, context.AcceptableSwitchingDistance);

        ToPatrollTransition toPatrol = new ToPatrollTransition(patrolState, context.PlayerDetector);
        ToChaseTransition toChase = new ToChaseTransition(patrolState, context.PlayerDetector);

        patrolState.AddTransition(toChase);
        
        chaseState.AddTransition(toPatrol);
        
        stateMachine.ChangeState(patrolState);
        
        return stateMachine;
    }
}