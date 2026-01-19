using System.Collections.Generic;
using UnityEngine;

public class OverlapTargetsSelector
{
    private float _radius;
    private LayerMask _layerMask;
    private Transform _transform;

    public OverlapTargetsSelector(float radius, LayerMask layerMask, Transform transform)
    {
        _radius = radius;
        _layerMask = layerMask;
        _transform = transform;
    }
    
    public IEnumerable<Rigidbody> SelectTargets()
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _radius, _layerMask);

        List<Rigidbody> targets = new List<Rigidbody>();

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody result))
                targets.Add(result);
        }

        return targets;
    }
}