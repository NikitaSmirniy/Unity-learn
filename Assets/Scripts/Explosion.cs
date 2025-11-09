using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionEffect;

    private void OnMouseUpAsButton()
    {
        ActivateExplosion();
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    public void ActivateExplosion()
    {
        foreach (Rigidbody explosionObject in GetExplodableObjects())
            explosionObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> hitObjects = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                hitObjects.Add(hit.attachedRigidbody);

        return hitObjects;
    }
}