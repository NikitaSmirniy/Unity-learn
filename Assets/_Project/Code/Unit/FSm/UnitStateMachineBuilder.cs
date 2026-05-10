using FSMTest;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Code
{
    public class UnitStateMachineBuilder
    {
        public StateMachine Build(Unit unit, NavMeshAgent agent, Transform baseTransform)
        {
            StateMachine stateMachine = new StateMachine();

            IdleState idleState = new IdleState(stateMachine);
            MoveToItemState moveToItemState = new MoveToItemState(stateMachine, agent, unit);
            MoveToBaseState moveToBaseState = new MoveToBaseState(stateMachine, agent, baseTransform);

            ToIdleTransition toIdleTransition = new ToIdleTransition(idleState, unit);
            ToMoveToItemTransition toMoveToItemTransition = new ToMoveToItemTransition(moveToItemState, unit);
            ToMoveToBaseTransition toMoveToBaseTransition = new ToMoveToBaseTransition(moveToBaseState, unit);

            idleState.AddTransition(toMoveToItemTransition);
            idleState.AddTransition(toMoveToBaseTransition);

            moveToItemState.AddTransition(toMoveToBaseTransition);
            moveToItemState.AddTransition(toMoveToItemTransition);

            moveToBaseState.AddTransition(toIdleTransition);
            moveToBaseState.AddTransition(toMoveToItemTransition);

            stateMachine.ChangeState(idleState);

            return stateMachine;
        }
    }
}