using System;
using UnityEngine;

[RequireComponent(typeof(TouchedDetector))]
[RequireComponent(typeof(MoverHandler))]
public class Cube : MonoBehaviour
{
    private TouchedDetector _touchedDetector;
    private MoverHandler MoverHandler;

    public event Action<Cube> Dead;

    private void Awake()
    {
        _touchedDetector = GetComponent<TouchedDetector>();
        MoverHandler = GetComponent<MoverHandler>();
        SetDefaultValues();
    }

    private void OnEnable()
    {
        _touchedDetector.Touched += Die;
    }

    private void OnDisable()
    {
        _touchedDetector.Touched -= Die;
    }

    public void SetDefaultValues()
    {
        transform.rotation = Quaternion.identity;
        _touchedDetector.SetDefault();
    }

    public void Init(Vector3 startPosition, Vector3 moveDirection)
    {
        transform.position = startPosition;
        MoverHandler.SetDirection(moveDirection);
    }

    private void Die()
    {
        Dead?.Invoke(this);
    }
}