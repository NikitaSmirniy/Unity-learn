using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _minLiveTime = 2;
    [SerializeField] private int _maxLiveTime = 5;

    private Renderer _renderer;
    private TouchedDetector _touchedDetector;
    
    public event Action<Cube> Lived;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _touchedDetector = GetComponent<TouchedDetector>();
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
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _touchedDetector.SetDefault();
    }

    private void StartLiveTime() => StartCoroutine(StartCounter());

    private IEnumerator StartCounter()
    {
        _renderer.material.color = Color.yellow;

        yield return new WaitForSeconds(Random.Range(_minLiveTime, _maxLiveTime));

        Lived?.Invoke(this);
    }
}