using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    public event Action MoveMouseButtonDown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            MoveMouseButtonDown?.Invoke();
        }
    }
}