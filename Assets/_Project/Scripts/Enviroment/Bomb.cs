using System;
using System.Collections;
using UnityEngine;

public class Bomb : UnitBase, ICoroutinesRunner
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ColorRenderer _colorRenderer;
    [SerializeField] private TimerConfig timerConfig;
    [SerializeField] private float _force = 1000;
    [SerializeField] private float _radius = 10;

    private Timer _timer;
    private OverlapTargetsSelector _overlapTargetsSelector;
    private Exploder _exploder;

    public event Action<Bomb> Dead;

    private void Awake()
    {
        _timer = new Timer(timerConfig, this);
        _overlapTargetsSelector = new OverlapTargetsSelector(_radius, _layerMask, transform);
        _exploder = new Exploder();
        _colorRenderer.SetModel(_timer);
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void StartExplodeTimer()
    {
        _timer.StartTimer(() =>
            _exploder.Explode(_overlapTargetsSelector.SelectTargets(), _force, transform, _radius, OnDead));
    }

    public Coroutine StartRoutine(IEnumerator enumerator)
    {
        return StartCoroutine(enumerator);
    }

    private void OnDead() =>
        Dead?.Invoke(this);
}