using FSMTest;
using UnityEngine.AI;

namespace _Project.Code
{
    public class MoveToItemState : FsmState
    {
        private NavMeshAgent _agent;
        private Unit _unit;

        public MoveToItemState(IStateChanger stateChange, NavMeshAgent agent, Unit unit) : base(stateChange)
        {
            _agent = agent;
            _unit = unit;
        }

        protected override void OnUpdate()
        {
            _agent.SetDestination(_unit.TargetItem.transform.position);
        }
    }
}