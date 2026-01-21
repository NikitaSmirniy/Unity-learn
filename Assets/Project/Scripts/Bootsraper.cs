using UnityEngine;

public class Bootsraper : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Transform _birdSpawnPoint;
    [SerializeField] private BulletSpawner _bulletPlayerSpawnerPrefab;
    [SerializeField] private BulletSpawner _bulletEnemySpawnerPrefab;
    [SerializeField] private EnemySpawner _enemySpawnerPrefab;
    [SerializeField] private ValueChangedView _valueChangedView;
    [SerializeField] private GameOverObserver _gameOverObserver;
    [SerializeField] private float _maxRotationZoneZ;
    [SerializeField] private float _minRotationZoneZ;
    [SerializeField] private float _rotateSpeed;

    private BulletSpawner _createdPlayerBulletSpawner;
    private BulletSpawner _createdEnemyBulletSpawner;
    private EnemySpawner _createdEnemySpawner;
    private Bird _createdBird;

    private void Awake()
    {
        _createdPlayerBulletSpawner = Instantiate(_bulletPlayerSpawnerPrefab);
        _createdEnemyBulletSpawner = Instantiate(_bulletEnemySpawnerPrefab);
        
        _createdEnemySpawner = Instantiate(_enemySpawnerPrefab);
        _createdEnemySpawner.Init(_createdEnemyBulletSpawner);
        _createdBird = CreateBirdPlayer();
        HitObserver hitObserver = new HitObserver(_createdEnemySpawner);
        ScoreCounter scoreCounter = new ScoreCounter(hitObserver);

        _valueChangedView.Init(scoreCounter);

        _gameOverObserver.Init(_createdBird);
    }

    private Bird CreateBirdPlayer()
    {
        var bird = Instantiate(_bird, _birdSpawnPoint);
        LerpRotator lerpRotator = new LerpRotator(_maxRotationZoneZ, _minRotationZoneZ, _rotateSpeed);

        bird.Init(lerpRotator, _createdPlayerBulletSpawner);

        return bird;
    }
}