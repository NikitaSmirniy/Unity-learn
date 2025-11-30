using UnityEngine;

public class Mover : IMovable
{
    private Transform _transform;

    public Mover(Transform transform)
    {
        _transform = transform;
    }

    public void Move(Vector3 direction, float moveSpeed)
    {
        _transform.position += (direction * moveSpeed);
    }
}