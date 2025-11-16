using UnityEngine;

public class Exploser
{
    public void Execute(Rigidbody rigidbody, float force, float radius)
    {
        rigidbody.AddExplosionForce(force, rigidbody.transform.position, radius);
    }
}