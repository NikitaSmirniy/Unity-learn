using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRootView : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Transform _uISceneContainer;

    private void Awake()
    {
        HideLoadingScreen();
    }

    public void ShowLoadingScreen()
    {
        _loadingScreen.SetActive(true);
    }

    public void HideLoadingScreen()
    {
        _loadingScreen.SetActive(false);
    }

    public void AttachSceneUI(GameObject sceneUI)
    {
        ClearSceneUI();

        sceneUI.transform.SetParent(_uISceneContainer, false);
    }

    private void ClearSceneUI()
    {
        var childCount = _uISceneContainer.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Destroy(_uISceneContainer.GetChild(i).gameObject);
        }
    }
}