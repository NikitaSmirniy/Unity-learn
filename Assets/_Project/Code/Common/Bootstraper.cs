using System.Collections;
using _Project.Code;
using _Project.Code.Spawners;
using UnityEngine;

public class Bootstraper : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private ItemSpawner _itemSpawner;
    [SerializeField] private Unit _unitPrefab;
    [SerializeField] private Flag _flagPrefab;
    [SerializeField] private int _unitCount;
    [SerializeField] private Base _basePrefab;
    [SerializeField] private AmountView _amountView;
    [SerializeField] private InputService _inputService;
    [SerializeField] private LayerMask _ignoredLayers;

    private ItemSpawningSystem _itemSpawningSystem;
    private BaseItemAmountPresenter _baseItemAmountPresenter;
    private BaseColonisationHandler _baseColonisationHandler;

    private void Awake()
    {
        UnitStateMachineBuilder unitStateMachineBuilder = new UnitStateMachineBuilder();
        UnitFactory unitFactory = new UnitFactory(_unitPrefab, this, unitStateMachineBuilder);
        ContainerOccupiedItems containerOccupiedItems = new ContainerOccupiedItems();
        BaseFactory baseFactory = new BaseFactory(_basePrefab, unitFactory, _flagPrefab, containerOccupiedItems);

        Base newBase = baseFactory.Create(transform.position);

        for (int i = 0; i < _unitCount; i++)
        {
            newBase.AddUnit(unitFactory.Create(newBase.transform));
        }

        _baseItemAmountPresenter = new BaseItemAmountPresenter(_amountView, _basePrefab);
        _baseItemAmountPresenter.Enable();

        _itemSpawner.Init();
        _itemSpawningSystem = new ItemSpawningSystem(_itemSpawner, this);

        MonoObjectsSelector monoObjectsSelector = new MonoObjectsSelector();

        _baseColonisationHandler =
            new BaseColonisationHandler(monoObjectsSelector, _inputService);
    }

    private void OnDestroy()
    {
        _itemSpawningSystem.Dispose();
        _baseItemAmountPresenter.Dispose();
        _baseColonisationHandler.Dispose();
    }

    public void RunCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}