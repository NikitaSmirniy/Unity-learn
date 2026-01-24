using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(DetectorObstacle))]
public class Enemy : MonoBehaviour, IDamageable, IHitable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;
    [SerializeField] private bool _isShooting;

    private DetectorObstacle _detectorObstacle;
    private Mover _mover;
    private WaitForSeconds _wait;

    public event Action<Enemy> Dead;
    public event Action<IHitable> Hit;

    public Weapon Weapon { get; private set; }

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        Weapon = GetComponent<Weapon>();
        _detectorObstacle = GetComponent<DetectorObstacle>();

        _wait = new WaitForSeconds(_shootDelay);
    }

    private void OnEnable()
    {
        _detectorObstacle.Detected += OnObstacleDetected;
        StartCoroutine(ShootRoutine());
    }

    private void OnDisable()
    {
        _detectorObstacle.Detected -= OnObstacleDetected;
        StopCoroutine(ShootRoutine());
    }

    private void Update()
    {
        _mover.Move(Vector2.left * _speed);
    }

    public void TakeDamage()
    {
        Hit?.Invoke(this);
        Dead?.Invoke(this);
    }

    private IEnumerator ShootRoutine()
    {
        while (_isShooting)
        {
            yield return _wait;

            Weapon.Shoot();
        }
    }

    private void OnObstacleDetected(Obstacle obstacle)
    {
        Dead?.Invoke(this);
    }
}