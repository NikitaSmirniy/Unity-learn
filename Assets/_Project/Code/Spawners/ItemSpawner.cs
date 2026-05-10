using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item _prefab;
    [SerializeField] private int _startCount;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private int _randomSpawnPointDiaposone;

    private PoolMono<Item> _poolMono;
    
    public event Action ItemDestroyed;
    
    public void Init()
    {
        _poolMono = new PoolMono<Item>(_prefab, _startCount, _autoExpand, transform);
    }

    public void Spawn()
    {
        Item newItem = _poolMono.GetFreeEelement();

        Vector3 newRandomPosition = new Vector3(Random.Range(-_randomSpawnPointDiaposone, _randomSpawnPointDiaposone) + transform.position.x, 0,
            Random.Range(-_randomSpawnPointDiaposone, _randomSpawnPointDiaposone)+transform.position.z);
        
        newItem.transform.position = newRandomPosition;
        newItem.gameObject.SetActive(true);
        newItem.SetDefaultValues();

        newItem.Dead += OnDead;
    }

    private void OnDead(Item item)
    {
        item.Dead -= OnDead;
        
        item.gameObject.SetActive(false);
        item.transform.SetParent(transform);
        _poolMono.TakeElement(item);
        
        ItemDestroyed?.Invoke();
    }
}