using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            Coin createdCoin = Instantiate(_coinPrefab, spawnPoint.position, Quaternion.identity);
            createdCoin.Collected += OnCollected;
        }
    }

    private void OnCollected(Coin coin)
    {
        coin.Collected -= OnCollected;
        Destroy(coin.gameObject);
    }
}