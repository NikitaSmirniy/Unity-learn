using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TouchedDetector))]
public class Cube : UnitBase
{
    [SerializeField] private float _minLiveTime = 2;
    [SerializeField] private int _maxLiveTime = 5;

    private Renderer _renderer;
    
    private TouchedDetector _touchedDetector;

    private Coroutine _liveTimer;
    
    public event Action<Cube> Dead;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _touchedDetector = GetComponent<TouchedDetector>();
        Rigidbody = GetComponent<Rigidbody>();
        SetDefaultValues();
    }

    private void OnEnable()
    {
        _touchedDetector.Touched += StartLiveTime;
    }

    private void OnDisable()
    {
        _touchedDetector.Touched -= StartLiveTime;
    }

    public void SetDefaultValues()
    {
        _renderer.material.color = Color.cyan;
        Rigidbody.velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _touchedDetector.SetDefault();
    }

    private void StartLiveTime()
    {
        if (_liveTimer == null)
            _liveTimer = StartCoroutine(StartCounter());
    }

    private IEnumerator StartCounter()
    {
        _renderer.material.color = Color.yellow;

        yield return new WaitForSeconds(Random.Range(_minLiveTime, _maxLiveTime));
        
        _liveTimer = null;
        
        Dead?.Invoke(this);
    }
}