using System.Collections.Generic;
using UnityEngine;

public class OverlaperExplosionCube : MonoBehaviour
{
    public List<ExplosionCube> Execute(Vector3 position, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(position, radius);

        List<ExplosionCube> explosionCubes = new();

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<ExplosionCube>(out ExplosionCube explosionCube))
                explosionCubes.Add(explosionCube);
        }

        return explosionCubes;
    }
}