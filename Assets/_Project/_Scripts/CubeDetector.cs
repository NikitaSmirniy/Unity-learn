using System.Collections.Generic;
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    public List<ExplosionCube> Detect(Vector3 position, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(position, radius);

        List<ExplosionCube> detectedExplosionCubes = new();

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<ExplosionCube>(out ExplosionCube resource))
                detectedExplosionCubes.Add(resource);
        }

        return detectedExplosionCubes;
    }
}