using UnityEngine;

public class SpawnerBase<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _startCountInPool;
    [SerializeField] private bool _autoExpand;

    protected PoolMono<T> Pool;

    private void Awake()
    {
        Pool = new PoolMono<T>(_prefab, _startCountInPool, _autoExpand, transform);
    }
}