using FSMTest;
using UnityEngine;
using Cinemachine;

public class BootStraper : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private CinemachineVirtualCamera _camera;
    
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _enemySpawnPoint;
    [SerializeField] private Transform[]  _points;
    
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
        
        _createdEnemy.Init(rotatorTransform,
        enemyFsmFactory, wayPointsContainer);
    }
    
    private void InitPlayer()
    {
        _createdPlayer = CreatePlayer();

        InputService inputService = new InputService();
        RotatorTransform rotatorTransform = new RotatorTransform();
        Wallet wallet = new Wallet();
        PlayerFsmFactory playerFsmFactory = new PlayerFsmFactory();

        _createdPlayer.Init(inputService, rotatorTransform, wallet, playerFsmFactory);
        
        var createdCamera = Instantiate(_camera);
        createdCamera.Follow = _createdPlayer.transform;
    }
}