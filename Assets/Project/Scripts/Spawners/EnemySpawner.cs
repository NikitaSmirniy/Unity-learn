using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : SpawnerBase<Enemy>, IHitPublisher
{
    [SerializeField] private float _minSpawnOffsetY;
    [SerializeField] private float _maxSpawnOffsetY;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private bool _isWorking;
    [SerializeField] private float _duration;
    
    private BulletSpawner _bulletSpawner;

    private WaitForSeconds _wait;

    public event Action<IHitable> Hit;
    
    private void Start()
    {
        _wait = new WaitForSeconds(_duration);

        StartCoroutine(Spawn());
    }

    public void Init(BulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner;
    }

    public IEnumerator Spawn()
    {
        while (_isWorking)
        {
            yield return _wait;

            var freeEnemy = Pool.GetFreeEelement();
            freeEnemy.Weapon.Init(_bulletSpawner, Vector2.left);

            freeEnemy.transform.position = _spawnPoint.position +
                                           new Vector3(0, Random.Range(_minSpawnOffsetY, _maxSpawnOffsetY), 0);
            freeEnemy.gameObject.SetActive(true);
            freeEnemy.Shoot();
            freeEnemy.Dead += OnDead;
        }
    }

    private void OnDead(Enemy enemy)
    {
        enemy.Dead -= OnDead;
        enemy.gameObject.SetActive(false);
        Hit?.Invoke(enemy);
        Pool.TakeElement(enemy);
    }
}