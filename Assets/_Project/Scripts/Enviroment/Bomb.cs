using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, ICorouitinesRunner
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ColorRenderer _colorRenderer;
    [SerializeField] private TimerData _timerData;
    [SerializeField] private float _force = 1000;
    [SerializeField] private float _radius = 10;

    private Timer _timer;
    
    public event Action<Bomb> Exploded;

    private void Awake()
    {
        _timer = new Timer(_timerData, this);
        _colorRenderer.SetModel(_timer);
    }

    public void Explode()
    {
        _timer.StartTimer(() => Action(SelectTargets()));
    }
    
    public Coroutine StartRoutine(IEnumerator enumerator)
    {
        return StartCoroutine(enumerator);
    }

    private void Action(IEnumerable<Cube> targets)
    {
        foreach (var target in targets)
            target.Rigidbody.AddExplosionForce(_force, transform.position,_radius);
        
        Exploded?.Invoke(this);
    }

    private IEnumerable<Cube> SelectTargets()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);

        List<Cube> targets = new List<Cube>();

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Cube result))
                targets.Add(result);
        }

        return targets;
    }
}