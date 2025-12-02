using UnityEngine;

public class TransformMover : IMovable
{
    private Transform _transform;

    public TransformMover(Transform transform)
    {
        _transform = transform;
    }

    public void Move(Vector3 direction, float moveSpeed)
    {
        _transform.position += (direction * moveSpeed);
    }
}