using System.Collections;
using _Project._Scripts;
using TMPro;
using UnityEngine;

public class CubeSpawnerView : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI _spawnedObjectsCountText;
    [SerializeField] private TextMeshProUGUI _createdObjectsCountText;
    [SerializeField] private TextMeshProUGUI _activeObjectsCountText;
    
    [SerializeField] private CubeSpawner _model;

    private void Start()
    {
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
    
    protected void OnSpawnedObjectsCountChanged()
    {
        _spawnedObjectsCountText.text = $"Заспавнено: {_model.SpawnedOjectsCount}";
    }

    private void OnCreatedObjectsCountChanged()
    {
        _createdObjectsCountText.text = $"Созданные объекты: {_model.PoolMonoModel.CreatedObjectsCount}";
    }
    
    private void OnActivatedObjectsCountChanged()
    {
        _activeObjectsCountText.text = $"Активные объекты: {_model.PoolMonoModel.GetActiveObjectsCount()}";
    }

    private IEnumerator SubscribeRoutine()
    {
        yield return new WaitWhile(() => _model == null);
        
        _model.PoolMonoModel.CreatedObjectsCountChanged += OnCreatedObjectsCountChanged;
        _model.PoolMonoModel.ActivatedObjectsCountChanged += OnActivatedObjectsCountChanged;
    }
    
    private IEnumerator UnSubscribeRoutine()
    {
        yield return new WaitWhile(() => _model == null);
        
        _model.PoolMonoModel.CreatedObjectsCountChanged -= OnCreatedObjectsCountChanged;
        _model.PoolMonoModel.ActivatedObjectsCountChanged -= OnActivatedObjectsCountChanged;
    }
}