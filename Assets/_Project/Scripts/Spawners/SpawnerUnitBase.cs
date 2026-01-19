using System;
using UnityEngine;

public abstract class SpawnerUnitBase<T> : MonoBehaviour where T : UnitBase
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected int StartPoolCubesCount = 3;
    [SerializeField] protected bool AutoExpand;

    private int _spawnedObjectsCount;

    protected PoolMono<T> PoolMono;

    public IPoolMonoModel PoolMonoModel;

    public int SpawnedObjectsCount => _spawnedObjectsCount;

    public event Action SpawnedObjectsCountChanged;

    private void Awake()
    {
        PoolMono = new PoolMono<T>(Prefab, StartPoolCubesCount, AutoExpand, transform);
        PoolMonoModel = PoolMono;
    }

    protected void AddCreatedObjectsCount()
    {
        _spawnedObjectsCount++;
        SpawnedObjectsCountChanged?.Invoke();
    }
}