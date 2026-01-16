using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private bool _isJump;
    private bool _isMouseDown;
    
    public Vector2 Direction {get; private set;}

    public event Action OnAbillityKeyDown;
    
    private void Update()
    {
        Direction = ReadDirectionInput();

        if (Input.GetKeyDown(KeyCode.Space))
            _isJump = true;
        
        if (Input.GetKey(KeyCode.Mouse0))
            _isMouseDown = true; 
        
        if (Input.GetKeyDown(KeyCode.R))
            OnAbillityKeyDown?.Invoke(); 
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);
    
    public bool GetIsMouseDown() => GetBoolAsTrigger(ref _isMouseDown);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
    
    private Vector2 ReadDirectionInput()
    {
        var inputHorizontal = Input.GetAxis(Horizontal);

        return new Vector2(inputHorizontal, 0);
    }
}