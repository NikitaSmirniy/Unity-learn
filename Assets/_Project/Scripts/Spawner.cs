using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _startPoolCubesCount = 3;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delay;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private bool _isWorking = true;

    private RandomDirectionGenerator _randomDirectionGenerator;
    private PoolMono<Cube> _poolMono;

    private void Start()
    {
        _poolMono = new PoolMono<Cube>(_prefab, _startPoolCubesCount, _autoExpand, transform);
        _randomDirectionGenerator = new RandomDirectionGenerator();

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        while (_isWorking)
        {
            yield return new WaitForSeconds(_delay);

            var freeCube = _poolMono.GetFreeEelement();
            var randomPosition = Random.Range(0, _spawnPoints.Length);
            var randomMoveDirection = _randomDirectionGenerator.Generate();
            freeCube.Init(_spawnPoints[randomPosition].position, randomMoveDirection);
            
            Debug.Log(randomMoveDirection);
            
            freeCube.gameObject.SetActive(true);
            freeCube.Dead += OnCubeDead;
        }
    }

    private void OnCubeDead(Cube cube)
    {
        cube.Dead -= OnCubeDead;
        cube.SetDefaultValues();
        _poolMono.TakeElement(cube);
        cube.gameObject.SetActive(false);
    }
}