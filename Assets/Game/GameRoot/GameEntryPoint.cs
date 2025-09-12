using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    private static GameEntryPoint _instance;
    private Coroutines _coroutines;
    private UIRootView _uIRoot;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutostartGame()
    {
        _instance = new GameEntryPoint();
        _instance.RunGAme();
    }

    private GameEntryPoint()
    {
        _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
        Object.DontDestroyOnLoad(_coroutines.gameObject);

        var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
        _uIRoot = Object.Instantiate(prefabUIRoot);
        Object.DontDestroyOnLoad(_uIRoot.gameObject);
    }

    private void RunGAme()
    {
#if UNITY_EDITOR
        var sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == Scenes.SampleScene)
        {
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
            return;
        }

        if (sceneName == Scenes.MENU)
        {
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }

        if (sceneName != Scenes.BOOT)
            return;
#endif

        _coroutines.StartCoroutine(LoadAndStartMainMenu());
    }

    private IEnumerator LoadAndStartGameplay()
    {
        _uIRoot.ShowLoadingScreen();

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.SampleScene);

        yield return new WaitForSeconds(7.5f);

        var sceneEntryPoint = Object.FindObjectOfType<GamePlayEntryPoint>();
        sceneEntryPoint.Run(_uIRoot);

        sceneEntryPoint.GoToMainMenuSceneRequested += () =>
        {
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        };

        _uIRoot.HideLoadingScreen();
    }

    private IEnumerator LoadAndStartMainMenu()
    {
        _uIRoot.ShowLoadingScreen();

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.MENU);

        yield return new WaitForSeconds(7.5f);

        var sceneEntryPoint = Object.FindObjectOfType<MainMenuEntryPoint>();
        sceneEntryPoint.Run(_uIRoot);

        sceneEntryPoint.GoToGameplaySceneRequested += () =>
        {
            _coroutines.StartCoroutine(LoadAndStartGameplay());
        };

        _uIRoot.HideLoadingScreen();
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}