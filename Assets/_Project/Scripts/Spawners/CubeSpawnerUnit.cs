using System.Collections;
using UnityEngine;

namespace _Project._Scripts
{
    public class CubeSpawnerUnit : SpawnerUnitBase<Cube>
    {
        [SerializeField] private float _delay;
        [SerializeField] private bool _isWorking = true;
        [SerializeField] private BombSpawnerUnit _bombSpawnerUnit;

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
                
                Cube freeCube = PoolMono.GetFreeEelement();
                freeCube.transform.position = _randomPositionGenerator.Generate();
                freeCube.Dead += OnCubeDead;
                freeCube.gameObject.SetActive(true);
                freeCube.SetDefaultValues();
                
                AddCreatedObjectsCount();
            }
        }

        private void OnCubeDead(Cube cube)
        {
            cube.Dead -= OnCubeDead;
            cube.gameObject.SetActive(false);
            _bombSpawnerUnit.Spawn(cube);
            PoolMono.TakeElement(cube);
        }
    }
}