using UnityEngine;

public class TransformMover
{
    private Transform _transform;

    public TransformMover(Transform transform)
    {
        _transform = transform;
    }

    public void Move(Vector2 direction, float speed)
    {
        _transform.Translate(direction * speed);
    }
}