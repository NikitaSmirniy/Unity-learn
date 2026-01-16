using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _startPoolEnemiesCount = 3;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _container;
    [SerializeField] private float _delay;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private bool _isWorking = true;

    private PoolMono<Enemy> _poolMono;
    private Transform _target;
    private WaitForSeconds _wait;

    private void Start()
    {
        _poolMono = new PoolMono<Enemy>(_prefab, _startPoolEnemiesCount, _autoExpand, _container);
        _wait = new WaitForSeconds(_delay);
    }

    public void StartSpawning()
    {
        if (_target != null)
            StartCoroutine(Create());
    }


    public void Init(Transform target)
    {
        _target = target;
    }

    private IEnumerator Create()
    {
        while (_isWorking)
        {
            yield return _wait;

            var freeEnemy = _poolMono.GetFreeEelement();
            var startPosition = Random.Range(0, _spawnPoints.Length);
            //freeEnemy.Init(_spawnPoints[startPosition].position, _target);

            freeEnemy.gameObject.SetActive(true);
            //freeEnemy.ReachedTarget += OnCubeReachedTarget;
        }
    }

    private void OnCubeReachedTarget(Enemy enemy)
    {
        //enemy.ReachedTarget -= OnCubeReachedTarget;
        //enemy.SetDefaultValues();
        _poolMono.TakeElement(enemy);
        enemy.gameObject.SetActive(false);
    }
}