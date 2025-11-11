using UnityEngine;

public class KeyBoardInput : IInputService
{
    public Vector2 GetAxis()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        return new Vector2(x, y);
    }
}