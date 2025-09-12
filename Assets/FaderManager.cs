using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaderManager : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    private bool _isLoading;

    private static FaderManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        if (camera == null)
            camera = Camera.main.gameObject;

        _instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(camera);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            LoadScene(Scenes.SampleScene);

        if (Input.GetKeyDown(KeyCode.Alpha1))
            LoadScene(Scenes.TESTSCENE0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            LoadScene(Scenes.MENU);
    }

    public void LoadScene(string sceneName)
    {
        if (_isLoading)
            return;

        var currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == sceneName)
            throw new Exception("You are trying to load already scene.");

        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        _isLoading = true;

        var waitFading = true;
        Fader.instance.FadeIn(() => waitFading = false);

        while (waitFading)
            yield return null;

        var async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
            yield return null;

        async.allowSceneActivation = true;

        waitFading = true;
        Fader.instance.FadeOut(() => waitFading = false);

        while (waitFading)
            yield return null;

        _isLoading = false;
    }
}