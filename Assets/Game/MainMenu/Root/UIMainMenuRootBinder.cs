using System;
using UnityEngine;

public class UIMainMenuRootBinder : MonoBehaviour
{
    public event Action GoToGameplayButtonClick;

    public void HandlerGoToGameplayButtonClick()
    {
        GoToGameplayButtonClick?.Invoke();
    }
}