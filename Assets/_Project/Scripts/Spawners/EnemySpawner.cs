using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _delay = 10;
    [SerializeField] private int _count = 5;
    [SerializeField] private int _enemyMaxHealthValue = 50;
    
    [SerializeField] private int _startPoolEnemiesCount = 3;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _autoExpand;
    
    private PoolMono<Enemy> _pool;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _pool = new PoolMono<Enemy>(_prefab, _startPoolEnemiesCount, _autoExpand, _container);
        _wait = new WaitForSeconds(_delay);
        
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < _count; i++)
        {
            Enemy createdEnemy = CreateEnemy();
            
            yield return _wait;
        }
    }

    private Enemy CreateEnemy()
    {
        return Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
    }
}