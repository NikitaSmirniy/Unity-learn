using System.Collections;
using FSMTest;
using UnityEngine;
using Cinemachine;

public class BootStraper : MonoBehaviour, ICorouitinesRunner
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private int _playerMaxHealthValue = 125;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private CinemachineVirtualCamera _camera;

    [SerializeField] private AbilityActionData _abilityAction;
    [SerializeField] private AbilityTimerData _abilityTimerData;
    [SerializeField] private AuraView _abilityAuraViewPrefab;
    [SerializeField] private float _rangeOfAction;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemyMaxHealthValue = 50;
    [SerializeField] private Transform _enemySpawnPoint;
    [SerializeField] private Transform[] _points;

    [SerializeField] private Canvas _canvasPrefab;
    [SerializeField] private View _viewPrefab;
    [SerializeField] private TimerView _timerView;

    private Player _createdPlayer;
    private Enemy _createdEnemy;
    private AbilityTimer _abilityTimer;

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

        var canvas = CreateCanvasAtTransform(_createdEnemy.transform);
        CreateHealthViewOnCanvas(health, canvas);
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

        VampireAbilityAction abilityAction = CreateAbilityAction(_abilityAction, _createdPlayer.PlayerHealth);

        TargetAbilityOverlapSelector overlapSelector = CreateTargetAbilitySelector(_createdPlayer.transform, _rangeOfAction);

        var ability = CreateAbility(abilityAction, overlapSelector, _createdPlayer.InputService, _abilityTimerData);
        
        CreateAuraView(_createdPlayer.transform, _abilityTimer);
        
        var canvas = CreateCanvasAtTransform(_createdPlayer.transform);
        CreateHealthViewOnCanvas(health, canvas);
    }

    private Ability CreateAbility(VampireAbilityAction vampireAbilityAction,
        TargetAbilityOverlapSelector targetAbilitySelector, InputService inputService, AbilityTimerData abilityTimerData) =>
        new Ability(vampireAbilityAction, targetAbilitySelector, inputService, CreateAbilityTimer());

    private VampireAbilityAction CreateAbilityAction(AbilityActionData abilityAction, IHealable healable) =>
        new VampireAbilityAction(abilityAction, healable);

    private TargetAbilityOverlapSelector CreateTargetAbilitySelector(Transform transform, float radius) =>
        new TargetAbilityOverlapSelector(transform, radius, _layerMask);
    
    private Canvas CreateCanvasAtTransform(Transform transform)
    {
        var createdCanvas = Instantiate(_canvasPrefab, transform.position, Quaternion.identity);
        createdCanvas.transform.SetParent(transform);

        return createdCanvas;
    }

    private void CreateHealthViewOnCanvas(IHealthModel health, Canvas canvas)
    {
        var createdHealthView = Instantiate(_viewPrefab, canvas.transform.position, Quaternion.identity);
        createdHealthView.transform.SetParent(canvas.transform);
        createdHealthView.SetModel(health);
        
        createdHealthView.transform.position = new Vector2(canvas.transform.position.x,
            canvas.transform.position.y + 1.25f);
    }

    private AbilityTimer CreateAbilityTimer()
    {
        _abilityTimer = new AbilityTimer(_abilityTimerData, this);
        
        _timerView.Init(_abilityTimer, _abilityTimer);
        
        return _abilityTimer;
    }

    private void CreateAuraView(Transform transform, IActionActivateObserver model)
    {
        var auraView = Instantiate(_abilityAuraViewPrefab, transform.position, Quaternion.identity);
        auraView.transform.SetParent(transform);
        
        auraView.SetModel(model);
    }

    public Coroutine StartRoutine(IEnumerator enumerator)
    {
        return StartCoroutine(enumerator);
    }
}