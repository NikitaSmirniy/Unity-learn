using System;
using UnityEngine;

[RequireComponent(typeof(DetectorObstacle))]
[RequireComponent(typeof(InputSystem))]
[RequireComponent(typeof(Weapon))]
public class Bird : MonoBehaviour, IDamageable, IGameOverPublisher
{
    [SerializeField] private float _tapForce;

    private DetectorObstacle _detector;
    private InputSystem _inputSystem;
    private Weapon _weapon;
    private Mover _mover;

    private LerpRotator _lerpRotator;

    public event Action<GameObject> GameOver;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _detector = GetComponent<DetectorObstacle>();
        _inputSystem = GetComponent<InputSystem>();
        _weapon = GetComponent<Weapon>();
    }

    private void Start()
    {
        _weapon.StartShootRoutine();
    }

    private void OnEnable()
    {
        _detector.Detected += OnDetected;
        _inputSystem.MoveMouseButtonDown += Move;
    }

    private void OnDisable()
    {
        _detector.Detected -= OnDetected;
        _inputSystem.MoveMouseButtonDown -= Move;
    }

    private void Update()
    {
        if (_mover.Rigidbody2D.velocity.y <= 0)
            _lerpRotator.MinRotate(transform);
    }

    public void Init(LerpRotator lerpRotator, BulletSpawner bulletSpawner)
    {
        _lerpRotator = lerpRotator;
        _weapon.Init(bulletSpawner, Vector2.right);
    }

    private void Move()
    {
        _mover.Move(Vector2.up * _tapForce);
        _lerpRotator.MaxRotate(transform);
    }

    private void OnDetected(Obstacle _)
    {
        Damage();
    }
    
    public void Damage()
    {
        GameOver?.Invoke(this.gameObject);
    }
}