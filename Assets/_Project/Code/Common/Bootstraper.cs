using System.Collections;
using System.Collections.Generic;
using _Project.Code;
using _Project.Code.Spawners;
using UnityEngine;

public class Bootstraper : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private ItemSpawner _itemSpawner;
    [SerializeField] private int _unitCount;
    [SerializeField] private Unit _unitPrefab;
    [SerializeField] private ItemDetector _detector;
    [SerializeField] private Base _base;
    [SerializeField] private AmountView _amountView;

    private ItemSpawningSystem _itemSpawningSystem;
    private BaseItemAmountPresenter _baseItemAmountPresenter;

    private void Awake()
    {
        UnitsFactory unitsFactory = new UnitsFactory(_unitPrefab, _base.transform);

        List<Unit> units = unitsFactory.Generate(_unitCount, transform);

        _base.Init(_detector, units);

        _baseItemAmountPresenter = new BaseItemAmountPresenter(_amountView, _base);
        _baseItemAmountPresenter.Enable();
        
        _itemSpawner.Init();
        _itemSpawningSystem = new ItemSpawningSystem(_itemSpawner, this);
    }

    private void OnDestroy()
    {
        _itemSpawningSystem.Dispose();
        _baseItemAmountPresenter.Dispose();
    }

    public void RunCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}