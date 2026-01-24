using UnityEngine.SceneManagement;

public class GameOverObserver
{
    private IDeathPublisher _deathPublisher;

    public GameOverObserver(IDeathPublisher deathPublisher)
    {
        _deathPublisher = deathPublisher;
        _deathPublisher.Dead += OnDead;
    }

    private void OnDead()
    {
        _deathPublisher.Dead -= OnDead;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}