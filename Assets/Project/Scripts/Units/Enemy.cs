using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(DetectorObstacle))]
public class Enemy : MonoBehaviour, IDamageable, IHitable
{
    [SerializeField] private float _speed;

    private DetectorObstacle _detectorObstacle;
    private Mover _mover;
    private float _currentTimerTime;

    public event Action<Enemy> Dead;
    public event Action<IHitable> Hit;

    public Weapon Weapon { get; private set; }

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        Weapon = GetComponent<Weapon>();
        _detectorObstacle = GetComponent<DetectorObstacle>();
    }

    private void OnEnable()
    {
        _detectorObstacle.Detected += OnObstacleDetected;
    }

    private void OnDisable()
    {
        _detectorObstacle.Detected -= OnObstacleDetected;
    }

    private void Update()
    {
        _mover.Move(Vector2.left * _speed);
    }

    public void Damage()
    {
        OnDead();
    }

    public void Shoot()
    {
        Weapon.StartShootRoutine();
    }

    private void OnObstacleDetected(Obstacle obstacle)
    {
        OnDead();
    }

    private void OnDead()
    {
        Hit?.Invoke(this);
        Dead?.Invoke(this);
        Weapon.Reset();
    }
}