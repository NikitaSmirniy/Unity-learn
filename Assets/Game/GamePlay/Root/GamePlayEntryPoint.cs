using System;
using UnityEngine;

public class GamePlayEntryPoint : MonoBehaviour
{
    public event Action GoToMainMenuSceneRequested;
    [SerializeField] private UIGameplayBinder _sceneUIRootPrefab;

    public void Run(UIRootView uIRoot)
    {
        var uIScene = Instantiate(_sceneUIRootPrefab);
        uIRoot.AttachSceneUI(uIScene.gameObject);

        uIScene.GoToMainMenuButtonClick += () =>
        {
            GoToMainMenuSceneRequested?.Invoke();
        };
    }
}