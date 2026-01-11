using FSMTest;
using UnityEngine;
using Cinemachine;

public class BootStraper : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private int _playerMaxHealthValue = 125;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private CinemachineVirtualCamera _camera;

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemyMaxHealthValue = 50;
    [SerializeField] private Transform _enemySpawnPoint;
    [SerializeField] private Transform[] _points;

    [SerializeField] private Canvas _canvasPrefab;
    [SerializeField] private HealthView _healthViewPrefab;

    private Player _createdPlayer;
    private Enemy _createdEnemy;

    private void Awake()
    {
        InitPlayer();
        InitEnemy();
    }

    private void OnEnable()
    {
        _createdPlayer.Enable();
        _createdEnemy.Enable();
    }

    private Player CreatePlayer()
    {
        return Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
    }

    private Enemy CreateEnemy()
    {
        return Instantiate(_enemyPrefab, _enemySpawnPoint.position, Quaternion.identity);
    }

    private void InitEnemy()
    {
        _createdEnemy = CreateEnemy();

        RotatorTransform rotatorTransform = new RotatorTransform();
        EnemyFsmFactory enemyFsmFactory = new EnemyFsmFactory();
        WayPointsContainer wayPointsContainer = new WayPointsContainer(_points);

        Health health = new Health(_enemyMaxHealthValue);

        _createdEnemy.Init(rotatorTransform,
            enemyFsmFactory, wayPointsContainer, health);

        var healthViewCanvas = CrateHealthViewWithCanvas(health);

        healthViewCanvas.transform.SetParent(_createdEnemy.transform);
        healthViewCanvas.transform.position = new Vector2(_createdEnemy.transform.position.x, _createdEnemy.transform.position.y + 1.25f);
    }

    private void InitPlayer()
    {
        _createdPlayer = CreatePlayer();

        RotatorTransform rotatorTransform = new RotatorTransform();
        Wallet wallet = new Wallet();
        PlayerFsmFactory playerFsmFactory = new PlayerFsmFactory();

        Health health = new Health(_playerMaxHealthValue);

        _createdPlayer.Init(rotatorTransform, wallet, playerFsmFactory, health);

        var createdCamera = Instantiate(_camera);
        createdCamera.Follow = _createdPlayer.transform;

        var healthViewCanvas = CrateHealthViewWithCanvas(health);

        healthViewCanvas.transform.SetParent(_createdPlayer.transform);
        healthViewCanvas.transform.position = new Vector2(_createdPlayer.transform.position.x, _createdPlayer.transform.position.y + 1.25f);
    }

    private Canvas CrateHealthViewWithCanvas(Health health)
    {
        var createdCanvas = Instantiate(_canvasPrefab, _createdPlayer.transform.position, Quaternion.identity);
        var createdHealthView = Instantiate(_healthViewPrefab, createdCanvas.transform.position, Quaternion.identity);
        createdHealthView.transform.SetParent(createdCanvas.transform);
        createdHealthView.Init(health);

        return createdCanvas;
    }
}