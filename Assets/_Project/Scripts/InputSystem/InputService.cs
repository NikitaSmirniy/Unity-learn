using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private bool _isJump;
    
    public Vector2 Direction {get; private set;}

    private void Update()
    {
        Direction = ReadInput();

        if (Input.GetKeyDown(KeyCode.Space))
            _isJump = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
    
    private Vector2 ReadInput()
    {
        var inputHorizontal = Input.GetAxis(Horizontal);

        return new Vector2(inputHorizontal, 0);
    }
}