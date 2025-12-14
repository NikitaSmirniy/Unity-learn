using UnityEngine;

public class RotatorTransform
{
    private const int RotateAngle = 180;
    
    public void Rotate(Transform transform, Vector2 direction)
    {
        if (direction.x > 0f)
            transform.rotation = new Quaternion(0, 0, 0,0);
        else if(direction.x < 0f)
            transform.rotation = new Quaternion(0, RotateAngle, 0,0);
    }
}