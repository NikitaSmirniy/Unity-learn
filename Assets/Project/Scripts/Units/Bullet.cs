using System;
using UnityEngine;

[RequireComponent(typeof(DetectorDamageable))]
[RequireComponent(typeof(DetectorObstacle))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletConfig _bulletConfig;

    private Mover _mover;
    private DetectorDamageable _detectorDamageable;
    private DetectorObstacle _detectorObstacle;
    private Vector2 _direction;
    private SpriteRenderer _renderer;
    private float _speed;

    public event Action<Bullet> Hit;

    private void Awake()
    {
        _mover = GetComponent<Mover>();

        _detectorDamageable = GetComponent<DetectorDamageable>();
        _detectorObstacle = GetComponent<DetectorObstacle>();
        _renderer = GetComponent<SpriteRenderer>();
        
        _renderer.sprite = _bulletConfig.Sprite;
        _speed = _bulletConfig.Speed;
    }

    private void OnEnable()
    {
        _detectorDamageable.Detected += OnDamageableDetected;
        _detectorObstacle.Detected += OnObstacleDetected;
    }

    private void OnDisable()
    {
        _detectorDamageable.Detected -= OnDamageableDetected;
        _detectorObstacle.Detected -= OnObstacleDetected;
    }

    public void FlyOutToDirection(Vector2 direction)
    {
        if (direction != null)
            SetDirection(direction);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _mover.Move(_direction * _speed * Time.deltaTime);
    }

    private void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void PerformDamage(IDamageable damageable)
    {
        damageable.Damage();
    }

    private void OnDamageableDetected(IDamageable damageable)
    {
        PerformDamage(damageable);

        OnHit();
    }

    private void OnObstacleDetected(Obstacle obstacle)
    {
        OnHit();
    }

    private void OnHit()
    {
        Hit?.Invoke(this);
    }
}