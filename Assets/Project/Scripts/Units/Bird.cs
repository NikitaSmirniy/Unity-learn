using System;
using UnityEngine;

[RequireComponent(typeof(DetectorObstacle))]
[RequireComponent(typeof(InputSystem))]
[RequireComponent(typeof(Weapon))]
public class Bird : MonoBehaviour, IDamageable, IDeathPublisher
{
    [SerializeField] private float _tapForce;

    private DetectorObstacle _detector;
    private InputSystem _inputSystem;
    private Weapon _weapon;
    private Mover _mover;

    private LerpRotator _lerpRotator;

    public event Action Dead;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _detector = GetComponent<DetectorObstacle>();
        _inputSystem = GetComponent<InputSystem>();
        _weapon = GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        _detector.Detected += OnObstacleDetected;
        _inputSystem.SpaceKeyDown += Move;
        _inputSystem.MouseButtonDown += OnShoot;
    }

    private void OnDisable()
    {
        _detector.Detected -= OnObstacleDetected;
        _inputSystem.SpaceKeyDown -= Move;
        _inputSystem.MouseButtonDown -= OnShoot;
    }

    private void Update()
    {
        if (_mover.Rigidbody2D.velocity.y <= 0)
            _lerpRotator.RotateToMinPosition(transform);
    }

    public void Init(LerpRotator lerpRotator, BulletSpawner bulletSpawner)
    {
        _lerpRotator = lerpRotator;
        _weapon.Init(bulletSpawner, transform.right);
    }

    public void TakeDamage()
    {
        Dead?.Invoke();
    }

    private void OnShoot()
    {
        _weapon.SetShootDirection(transform.right);
        _weapon.Shoot();
    }

    private void Move()
    {
        _mover.Move(Vector2.up * _tapForce);
        _lerpRotator.RotateToMaxPosition(transform);
    }

    private void OnObstacleDetected(Obstacle _)
    {
        Dead?.Invoke();
    }
}