using System.Collections;
using UnityEngine;

public class PoolCubes : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _startPoolCubesCount = 3;
    [SerializeField] private float _delay;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private bool _isWorking = true;

    private GenerateRandomPosition _generateRandomPosition;
    private PoolMono<Cube> _poolMono;

    private void Start()
    {
        _poolMono = new PoolMono<Cube>(_prefab, _startPoolCubesCount, _autoExpand, transform);
        _generateRandomPosition = new GenerateRandomPosition();

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        while (_isWorking)
        {
            yield return new WaitForSeconds(_delay);

            var freeCube = _poolMono.GetFreeEelement();
            freeCube.transform.position = _generateRandomPosition.Generate();
            freeCube.SetDefaultValues();
        }
    }
}