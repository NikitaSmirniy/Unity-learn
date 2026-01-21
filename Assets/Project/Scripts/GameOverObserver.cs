using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverObserver : MonoBehaviour
{
    private IGameOverPublisher _gameOverPublisher;

    public void Init(IGameOverPublisher gameOverPublisher)
    {
        _gameOverPublisher = gameOverPublisher;
        _gameOverPublisher.GameOver += OnGameOver;
    }

    private void OnGameOver(GameObject gameObject)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}