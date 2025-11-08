using System.Collections.Generic;
using UnityEngine;

namespace PoolObjects
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        private T _prefab;
        private Transform _container;
        private List<T> _pool;

        public bool AutoExpand { get; set; }

        public PoolMono(T prefab, int count)
        {
            _prefab = prefab;
            _container = null;

            CreatePool(count);
        }

        public PoolMono(T prefab, int count, Transform container)
        {
            _prefab = prefab;
            _container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(_prefab, _container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);

            return createdObject;
        }

        private bool HasFreeElement(out T element)
        {
            foreach (var mono in _pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);

                    return true;
                }
            }

            element = null;

            return false;
        }

        public T GetFreeEelement()
        {
            if (HasFreeElement(out var element))
                return element;

            if (AutoExpand)
                return CreateObject(true);

            throw new System.Exception("There is no free elements in pool");
        }
    }
}