using UnityEngine;

public class Character : Unit, IMoveable
{
    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
    }
}