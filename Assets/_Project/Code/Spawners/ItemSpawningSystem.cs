using System;
using System.Collections;
using UnityEngine;

namespace _Project.Code.Spawners
{
    public class ItemSpawningSystem : IDisposable
    {
        private ItemSpawner _spawner;
        private int _currentCount;
        private bool _isWorking = true;
        private WaitForSeconds _wait;

        private readonly int _maximumAllowedCount = 20;
        private readonly int _spawningInterval = 2;

        public ItemSpawningSystem(ItemSpawner spawner, ICoroutineRunner coroutineRunner)
        {
            _spawner = spawner;
            _spawner.ItemDestroyed += OnDestroyed;
            
            _wait = new WaitForSeconds(_spawningInterval);
            
            coroutineRunner.RunCoroutine(StartWorking());
        }

        public void Dispose()
        {
            _isWorking = false;
            _spawner.ItemDestroyed -= OnDestroyed;
        }

        private void OnDestroyed()
        {
            _currentCount--;
        }

        private IEnumerator StartWorking()
        {
            while (_isWorking)
            {
                if (_currentCount < _maximumAllowedCount)
                {
                    _spawner.Spawn();

                    _currentCount++;
                }

                yield return _wait;
            }
        }
    }
}