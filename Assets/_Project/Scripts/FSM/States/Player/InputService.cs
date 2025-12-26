using UnityEngine;

public class InputService
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public Vector2 ReadInput()
    {
        var inputHorizontal = Input.GetAxis(Horizontal);
        //var inputVertical = Input.GetAxis(Vertical);

        return new Vector2(inputHorizontal, 0);
    }
}