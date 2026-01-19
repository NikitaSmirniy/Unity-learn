using System.Collections;
using TMPro;
using UnityEngine;

public abstract class SpawnerViewBase<T> : MonoBehaviour where T : UnitBase
{
    [SerializeField] private TextMeshProUGUI _spawnedObjectsCountText;
    [SerializeField] private TextMeshProUGUI _createdObjectsCountText;
    [SerializeField] private TextMeshProUGUI _activeObjectsCountText;

    [SerializeField] private SpawnerUnitBase<T> _model;

    private WaitWhile _wait;

    private void Start()
    {
        _wait = new WaitWhile(() => _model == null);

        OnSpawnedObjectsCountChanged();
        OnCreatedObjectsCountChanged();
        OnActivatedObjectsCountChanged();
    }

    private void OnEnable()
    {
        if (_model != null)
        {
            _model.SpawnedObjectsCountChanged += OnSpawnedObjectsCountChanged;
            StartCoroutine(SubscribeRoutine());
        }
    }

    private void OnDisable()
    {
        if (_model != null)
        {
            _model.SpawnedObjectsCountChanged -= OnSpawnedObjectsCountChanged;
            StartCoroutine(UnSubscribeRoutine());
        }
    }

    private void OnSpawnedObjectsCountChanged()
    {
        _spawnedObjectsCountText.text = $"Заспавнено: {_model.SpawnedObjectsCount}";
    }

    private void OnCreatedObjectsCountChanged()
    {
        _createdObjectsCountText.text = $"Создано: {_model.PoolMonoModel.CreatedObjectsCount}";
    }

    private void OnActivatedObjectsCountChanged()
    {
        _activeObjectsCountText.text = $"Активные объекты: {_model.PoolMonoModel.GetActiveObjectsCount()}";
    }

    private IEnumerator SubscribeRoutine()
    {
        yield return _wait;

        _model.PoolMonoModel.CreatedObjectsCountChanged += OnCreatedObjectsCountChanged;
        _model.PoolMonoModel.ActivatedObjectsCountChanged += OnActivatedObjectsCountChanged;
    }

    private IEnumerator UnSubscribeRoutine()
    {
        yield return _wait;

        _model.PoolMonoModel.CreatedObjectsCountChanged -= OnCreatedObjectsCountChanged;
        _model.PoolMonoModel.ActivatedObjectsCountChanged -= OnActivatedObjectsCountChanged;
    }
}