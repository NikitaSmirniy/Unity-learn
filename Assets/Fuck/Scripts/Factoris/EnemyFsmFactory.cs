using FSMTest;

public class EnemyFsmFactory
{
    public StateMachine Create(EnemyFsmContext context)
    {
        StateMachine stateMachine = new StateMachine();

        PatrollState patrolState = new PatrollState(stateMachine, context.Mover, context.Speed,
            context.EnemyAnimatorHandler, context.WayPointsContainer, context.Enemy,
            context.AcceptableSwitchingDistance);

        ChaseState chaseState = new ChaseState(stateMachine, context.Mover, context.Speed,
            context.EnemyAnimatorHandler, context.Enemy, context.AcceptableSwitchingDistance);

        EnemyAttackState attackState = new EnemyAttackState(stateMachine, context.EnemyAnimatorHandler);
        EnemyDeathState deathState = new EnemyDeathState(stateMachine, context.EnemyAnimatorHandler);

        ToPatrollTransition toPatrol = new ToPatrollTransition(patrolState, context.PlayerDetector);
        ToChaseTransition toChase = new ToChaseTransition(chaseState, context.PlayerDetector);
        
        ToEnemyAttackTransition toAttack =
            new ToEnemyAttackTransition(attackState, context.Enemy, context.AcceptableSwitchingDistance);

        ToDeathTransition deathTransition = new ToDeathTransition(deathState, context.Health);

        patrolState.AddTransition(toChase);
        patrolState.AddTransition(deathTransition);

        chaseState.AddTransition(toPatrol);
        chaseState.AddTransition(toAttack);
        chaseState.AddTransition(deathTransition);

        attackState.AddTransition(toChase);

        stateMachine.ChangeState(patrolState);

        return stateMachine;
    }
}