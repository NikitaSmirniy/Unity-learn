using System;
using UnityEngine;

public class UIGameplayBinder : MonoBehaviour
{
    public event Action GoToMainMenuButtonClick;

    public void HandlerGoToMainMenuButtonClick()
    {
        GoToMainMenuButtonClick?.Invoke();
    }
}