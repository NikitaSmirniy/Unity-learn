using System;
using UnityEngine;

public class MainMenuEntryPoint : MonoBehaviour
{
    public event Action GoToGameplaySceneRequested;
    [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;

    public void Run(UIRootView uIRoot)
    {
        var uIScene = Instantiate(_sceneUIRootPrefab);
        uIRoot.AttachSceneUI(uIScene.gameObject);

        uIScene.GoToGameplayButtonClick += () =>
        {
            GoToGameplaySceneRequested?.Invoke();
        };
    }
}