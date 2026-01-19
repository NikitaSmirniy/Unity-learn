using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PoolMono<T> : IPoolMonoModel where T : MonoBehaviour
{
    private T _prefab;
    private Transform _container;
    private Queue<T> _pool;

    private bool _autoExpand;

    public int CreatedObjectsCount { get; private set; }
    
    public event Action CreatedObjectsCountChanged;
    public event Action ActivatedObjectsCountChanged;

    public PoolMono(T prefab, int count, bool autoExpand, Transform container)
    {
        _prefab = prefab;
        _container = container;
        _autoExpand = autoExpand;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new Queue<T>();

        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private T CreateObject()
    {
        var createdObject = Object.Instantiate(_prefab, _container);
        createdObject.gameObject.SetActive(false);

        _pool.Enqueue(createdObject);
        CreatedObjectsCount++;
        CreatedObjectsCountChanged?.Invoke();

        return createdObject;
    }

    private bool HasFreeElement()
    {
        return _pool.Count > 0;
    }
    
    public void TakeElement(T element)
    {
        _pool.Enqueue(element);
    }

    public T GetFreeEelement()
    {
        if (HasFreeElement())
        {
            ActivatedObjectsCountChanged?.Invoke();
            
            return _pool.Dequeue();
        }

        if (_autoExpand)
        {
            CreateObject();
            ActivatedObjectsCountChanged?.Invoke();
            
            return _pool.Dequeue();
        }

        throw new Exception("There is no free elements in pool");
    }
    
    public int GetActiveObjectsCount()
    {
        return CreatedObjectsCount - _pool.Count;
    }
}