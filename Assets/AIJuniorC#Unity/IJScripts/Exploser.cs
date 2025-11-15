using System.Collections.Generic;
using UnityEngine;

public class Exploser
{
    private float _radius = 5;
    private float _force = 500;

    public Exploser(float radius, float force)
    {
        _radius = radius;
        _force = force;
    }

    public void Execute(List<Rigidbody> rigidbodies)
    {
        foreach (var rigidbody in rigidbodies)
            rigidbody.AddExplosionForce(_force, rigidbody.transform.position, _radius);
    }
}