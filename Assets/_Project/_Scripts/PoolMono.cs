using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    private T _prefab;
    private Transform _container;
    private Queue<T> _pool;

    private bool _autoExpand;

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
        _pool.Enqueue(createdObject);

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
            return _pool.Dequeue();

        if (_autoExpand)
        {
            CreateObject();
            return _pool.Dequeue();
        }

        throw new System.Exception("There is no free elements in pool");
    }
}