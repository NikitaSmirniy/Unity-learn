using System;
using UnityEngine;

public class TargetReachedChecker
{
    private Vector3 _origin;
    private Vector3 _target;

    public event Action ReachedTarget;
    
    public TargetReachedChecker(Vector3 origin, Vector3 target)
    {
        _origin = origin;
        _target = target;
    }
    
    public TargetReachedChecker()
    {
        _origin = Vector3.zero;
        _target = Vector3.zero;
    }

    public void CheckReachedTarget()
    {
        if(HasReachedTarget())
            ReachedTarget?.Invoke();
    }
    
    private bool HasReachedTarget()
    {
        var acceptableSwitchingDistance = 0.25f;

        return Vector3.Distance(_origin, _target) <= acceptableSwitchingDistance;
    }
}