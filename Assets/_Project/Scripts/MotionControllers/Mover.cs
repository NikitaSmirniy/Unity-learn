using UnityEngine;

public class Mover
{
    private float _speed = 10;
    private Vector2 _targetPosition;

    public Mover(Rigidbody2D rigidbody, Vector2 targetPosition)
    {
        Rigidbody = rigidbody;
        _targetPosition = targetPosition;
    }

    public Rigidbody2D Rigidbody { get; private set; }
    
    public void Move(ForceMode2D forceMode = ForceMode2D.Force)
    {
        Rigidbody.AddForce(_targetPosition * _speed, forceMode);
    }

    public void Move(Vector2 direction, ForceMode2D forceMode = ForceMode2D.Force)
    {
        Vector2 distance = direction * _speed;
        
        Rigidbody.velocity = new Vector2(distance.x, distance.y + Rigidbody.velocity.y);
    }

    public void SetSpeed(float speed)
    {
        if (speed > 0)
            _speed = speed;
    }

    public void SetTarget(Vector2 target) =>
        _targetPosition = target;
}