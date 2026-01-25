using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    public event Action MouseButtonDown;
    public event Action SpaceKeyDown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
            MouseButtonDown?.Invoke();

        if (Input.GetKey(KeyCode.Space))
            SpaceKeyDown?.Invoke();
    }
}