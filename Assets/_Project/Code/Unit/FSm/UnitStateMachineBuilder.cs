using FSMTest;

namespace _Project.Code
{
    public class UnitStateMachineBuilder
    {
        public StateMachine Build(Unit unit)
        {
            StateMachine stateMachine = new StateMachine();

            IdleState idleState = new IdleState(stateMachine);
            MoveToTargetState moveToTargetState = new MoveToTargetState(stateMachine, unit);
            MoveToBaseState moveToBaseState = new MoveToBaseState(stateMachine, unit);
            BuildingBaseState buildingBaseState = new BuildingBaseState(stateMachine);
            
            ToIdleTransition toIdleTransition = new ToIdleTransition(idleState, unit);
            ToMoveToTargetTransition toMoveToTargetTransition = new ToMoveToTargetTransition(moveToTargetState, unit);
            ToMoveToBaseTransition toMoveToBaseTransition = new ToMoveToBaseTransition(moveToBaseState, unit);
            ToBuildingBaseTransition toBuildingBaseTransition = new ToBuildingBaseTransition(buildingBaseState, unit);

            idleState.AddTransition(toMoveToTargetTransition);
            idleState.AddTransition(toMoveToBaseTransition);

            moveToTargetState.AddTransition(toMoveToBaseTransition);
            moveToTargetState.AddTransition(toBuildingBaseTransition);
            moveToTargetState.AddTransition(toIdleTransition);

            moveToBaseState.AddTransition(toIdleTransition);
            moveToBaseState.AddTransition(toMoveToTargetTransition);

            buildingBaseState.AddTransition(toIdleTransition);
            
            stateMachine.ChangeState(idleState);

            return stateMachine;
        }
    }
}