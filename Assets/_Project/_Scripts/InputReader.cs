using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int ClickButtonDown =0;  
        
    public event Action Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(ClickButtonDown))
            Clicked?.Invoke();
    }
}