using FSMTest;
using UnityEngine;
using UnityEngine.AI;

public class MoveToBaseState : FsmState
{
    private NavMeshAgent _agent;
    private Transform _baseTransform;

    public MoveToBaseState(IStateChanger stateChange, NavMeshAgent agent, Transform baseTransform) : base(stateChange)
    {
        _agent = agent;
        _baseTransform = baseTransform;
    }

    protected override void OnUpdate()
    {
        _agent.SetDestination(_baseTransform.position);
    }
}