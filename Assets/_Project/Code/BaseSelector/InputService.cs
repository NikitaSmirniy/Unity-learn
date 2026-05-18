using System;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public event Action LeftMouseButtonDown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            LeftMouseButtonDown?.Invoke();
    }
}