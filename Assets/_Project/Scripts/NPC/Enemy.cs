using FSMTest;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyHealthHandler))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _acceptableSwitchingDistance = 0.25f;
    [SerializeField] private ObstacleCheker _obstacleCheker;
    [SerializeField] private EnemyAnimatorHandler _enemyAnimatorHandler;
    [SerializeField] private EnemyHealthHandler _healthHandler;
    [SerializeField] private PlayerDetector _playerDetector;

    private WayPointsContainer _wayPointsContainer;

    private RotatorTransform _rotatorTransform;
    private AudioPlayer _audioPlayer;
    private EnemyFsmFactory _enemyFsmFactory;
    private Rigidbody2D _rigidbody;

    private StateMachine _stateMachine;
    public Transform Target { get; private set; }

    public void Enable()
    {
        _playerDetector.Touched += OnFoundTarget;
    }

    private void OnDisable()
    {
        _playerDetector.Touched -= OnFoundTarget;
    }

    private void Update()
    {
        _rotatorTransform.Rotate(transform, Target.position - transform.position);

        _stateMachine.Update();
    }

    public void Init(RotatorTransform rotatorTransform,
        EnemyFsmFactory enemyFsmFactory, WayPointsContainer wayPointsContainer, Health health)
    {
        _rotatorTransform = rotatorTransform;
        _enemyFsmFactory = enemyFsmFactory;
        _wayPointsContainer = wayPointsContainer;

        _rigidbody = GetComponent<Rigidbody2D>();
        _healthHandler.Init(health);

        Mover mover = new Mover(_rigidbody);

        SetTarget(_wayPointsContainer.CurrentWayPoint);

        var context =
            new EnemyFsmContext(mover, _runSpeed, _obstacleCheker, _enemyAnimatorHandler, _playerDetector,
                _wayPointsContainer,
                _acceptableSwitchingDistance, this, health);

        _stateMachine = _enemyFsmFactory.Create(context);
    }

    public void SetTarget(Transform target)
    {
        if (target != null)
            Target = target;
    }

    private void OnFoundTarget()
    {
        Target = _playerDetector.TouchedComponent.transform;
    }
}