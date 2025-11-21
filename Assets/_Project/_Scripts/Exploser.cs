using UnityEngine;

public class Exploser
{
    public void Execute(Rigidbody explosiableRigidbody, Vector3 explosionPosotion,float force, float radius)
    {
        explosiableRigidbody.AddExplosionForce(force, explosionPosotion, radius,3);
    }
}