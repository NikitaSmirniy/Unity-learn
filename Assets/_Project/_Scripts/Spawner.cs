using System.Collections;
using UnityEngine;

namespace _Project._Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Cube _prefab;
        [SerializeField] private int _startPoolCubesCount = 3;
        [SerializeField] private float _delay;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private bool _isWorking = true;

        private RandomPositionGenerator _randomPositionGenerator;
        private PoolMono<Cube> _poolMono;

        private void Start()
        {
            _poolMono = new PoolMono<Cube>(_prefab, _startPoolCubesCount, _autoExpand, transform);
            _randomPositionGenerator = new RandomPositionGenerator();

            StartCoroutine(Create());
        }

        private IEnumerator Create()
        {
            while (_isWorking)
            {
                yield return new WaitForSeconds(_delay);

                var freeCube = _poolMono.GetFreeEelement();
                freeCube.transform.position = _randomPositionGenerator.Generate();
                freeCube.Lived += OnCubeLived;
                freeCube.gameObject.SetActive(true);
                freeCube.SetDefaultValues();
            }
        }

        private void OnCubeLived(Cube cube)
        {
            cube.Lived -= OnCubeLived;
            cube.gameObject.SetActive(false);
            _poolMono.TakeElement(cube);
        }
    }
}