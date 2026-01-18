using System.Collections;
using UnityEngine;

namespace _Project._Scripts
{
    public class CubeSpawner : SpawnerBase<Cube>
    {
        [SerializeField] private float _delay;
        [SerializeField] private bool _isWorking = true;
        [SerializeField] private BombSpawner _bombSpawner;

        private RandomPositionGenerator _randomPositionGenerator;

        private void Start()
        {
            _randomPositionGenerator = new RandomPositionGenerator();

            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_isWorking)
            {
                yield return new WaitForSeconds(_delay);
                
                var freeCube = PoolMono.GetFreeEelement();
                freeCube.transform.position = _randomPositionGenerator.Generate();
                freeCube.Dead += OnCubeDead;
                freeCube.Dead += _bombSpawner.Spawn;
                freeCube.gameObject.SetActive(true);
                freeCube.SetDefaultValues();
                
                AddCreatedObjectsCount();
            }
        }

        private void OnCubeDead(Cube cube)
        {
            cube.Dead -= OnCubeDead;
            cube.Dead -= _bombSpawner.Spawn;
            cube.gameObject.SetActive(false);
            PoolMono.TakeElement(cube);
        }
    }
}