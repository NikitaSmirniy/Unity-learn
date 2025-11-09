using UnityEngine;

public class Player : Unit, IMoveable
{
    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
    }
}