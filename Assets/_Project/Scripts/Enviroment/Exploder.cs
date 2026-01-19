using System;
using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    public void Explode(IEnumerable<Rigidbody> targets, float force, Transform origin, float radius, Action action = null)
    {
        foreach (var target in targets)
            target.AddExplosionForce(force, origin.position, radius);
        
        action?.Invoke();
    }
}