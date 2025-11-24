using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private TouchedDetector _touchedDetector;
    private LiveTimeGenerator _liveTimeGenerator;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _touchedDetector = GetComponent<TouchedDetector>();
        _liveTimeGenerator = new LiveTimeGenerator();
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
        _touchedDetector.SetDefault();
    }

    private void StartLiveTime() => StartCoroutine(StartCounter(_liveTimeGenerator.Generate()));

    private IEnumerator StartCounter(float delay)
    {
        _renderer.material.color = Color.yellow;

        yield return new WaitForSeconds(delay);

        gameObject.SetActive(false);
    }
}