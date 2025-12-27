using FSMTest;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerDetector))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _acceptableSwitchingDistance = 0.25f;
    [SerializeField] private ObstacleCheker _obstacleCheker;
    [SerializeField] private AnimatorHandler _animator;

    private WayPointsContainer _wayPointsContainer;

    private RotatorTransform _rotatorTransform;
    private AudioPlayer _audioPlayer;
    private EnemyFsmFactory _enemyFsmFactory;
    private Rigidbody2D _rigidbody;
    private PlayerDetector _playerDetector;

    private StateMachine _stateMachine;
    private Transform _target;

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
        _rotatorTransform.Rotate(transform, _target.position);

        _stateMachine.Update();
    }

    public void Init(RotatorTransform rotatorTransform,
        EnemyFsmFactory enemyFsmFactory, WayPointsContainer wayPointsContainer)
    {
        _rotatorTransform = rotatorTransform;
        _enemyFsmFactory = enemyFsmFactory;
        _wayPointsContainer = wayPointsContainer;

        _rigidbody = GetComponent<Rigidbody2D>();
        _playerDetector = GetComponent<PlayerDetector>();

        Mover mover = new Mover(_rigidbody, Vector2.zero);

        SetTarget(_wayPointsContainer.CurrentWayPoint);

        var context =
            new EnemyFsmContext(mover, _runSpeed, _obstacleCheker, _animator, _playerDetector, _wayPointsContainer, 0.25f, _target, transform);
        
        _stateMachine = _enemyFsmFactory.Create(context);
    }
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void OnFoundTarget()
    {
        _target.position = _playerDetector.TouchedComponent.transform.position;
    }
}