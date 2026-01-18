using System;
using UnityEngine;

public abstract class SpawnerBase<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected int StartPoolCubesCount = 3;
    [SerializeField] protected bool AutoExpand;
    
    private int _spawnedOjectsCount;

    protected PoolMono<T> PoolMono;
    
    public IPoolMonoModel PoolMonoModel;
    
    public int SpawnedOjectsCount => _spawnedOjectsCount;

    public event Action SpawnedObjectsCountChanged;

    private void Awake()
    {
        PoolMono = new PoolMono<T>(Prefab, StartPoolCubesCount, AutoExpand, transform);
        PoolMonoModel = PoolMono;
    }

    protected void AddCreatedObjectsCount()
    {
        _spawnedOjectsCount++;
        SpawnedObjectsCountChanged?.Invoke();
    }
}