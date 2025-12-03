using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class NPC : MonoBehaviour
{
    protected Mover _mover;

    public void Init(Vector3 startPosition, Transform target)
    {
        transform.position = startPosition;
        _mover.SetTarget(target);
    }
}