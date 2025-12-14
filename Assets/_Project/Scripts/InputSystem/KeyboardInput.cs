using UnityEngine;

public class KeyboardInput
{
    public Vector2 GetAxis()
    {
        var x = Input.GetAxis("Horizontal");

        return new Vector2(x, 0);
    }
}