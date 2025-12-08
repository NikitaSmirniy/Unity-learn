using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AnimatorHandler))]
public class Thief : MonoBehaviour
{
    [SerializeField] private float _acceptableSwitchingDistance = 0.25f;
    [SerializeField] private float _walkSpeed = 4;
    [SerializeField] private float _runSpeed = 12;

    private WayPointsContainer _wayPointsContainer;
    private NavMeshAgent _agent;
    private AnimatorHandler _animatorHandler;

    private bool _isDetected;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (HasGetTarget())
        {
            _wayPointsContainer?.ChangeCurrent();
            _agent.SetDestination(_wayPointsContainer.CurrentWayPoint.position);
            _animatorHandler.SetAnimation(GetNormalizedSpeed());
        }
    }

    public void SetIsDetected(bool isDetected)
    {
        _isDetected = isDetected;

        SetCurrentSpeed();
        _animatorHandler.SetAnimation(GetNormalizedSpeed());
    }
    
    public void Init(WayPointsContainer wayPointsContainer)
    {
        _wayPointsContainer = wayPointsContainer;
    }
    
    private void Init()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _walkSpeed;
        _agent.SetDestination(_wayPointsContainer.CurrentWayPoint.position);

        _animatorHandler = GetComponent<AnimatorHandler>();
        _animatorHandler.SetAnimation(GetNormalizedSpeed());
    }

    private void SetCurrentSpeed() =>
        _agent.speed = !_isDetected ? _walkSpeed : _runSpeed;

    private float GetNormalizedSpeed()
    {
        float currentSpeed = _agent.speed;
        float maxSpeed = _runSpeed;

        return currentSpeed / maxSpeed;
    }

    private bool HasGetTarget() =>
        (_agent.destination - transform.position).sqrMagnitude <= _acceptableSwitchingDistance;
}