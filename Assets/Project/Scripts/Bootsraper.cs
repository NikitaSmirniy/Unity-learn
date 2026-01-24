using UnityEngine;

public class Bootsraper : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Transform _birdSpawnPoint;
    [SerializeField] private BulletSpawner _bulletPlayerSpawner;
    [SerializeField] private BulletSpawner _bulletEnemySpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private ValueChangedView _valueChangedView;
    [SerializeField] private float _maxRotationZoneZ;
    [SerializeField] private float _minRotationZoneZ;
    [SerializeField] private float _rotateSpeed;

    private Bird _createdBird;
    private ScoreCounter _createdScoreCounter;

    private void OnDisable()
    {
        _createdScoreCounter.Dispose();
    }

    private void Awake()
    {
        _enemySpawner.Init(_bulletEnemySpawner);
        
        PlayerCreator playerCreator = new PlayerCreator(_bird, _bulletPlayerSpawner, _birdSpawnPoint, _maxRotationZoneZ,
            _minRotationZoneZ, _rotateSpeed);
        _createdBird = playerCreator.Create();

        HitObserver hitObserver = new HitObserver(_enemySpawner);
        _createdScoreCounter = new ScoreCounter(hitObserver);

        _valueChangedView.Init(_createdScoreCounter);

        GameOverObserver gameOverObserver = new GameOverObserver(_createdBird);
    }
}