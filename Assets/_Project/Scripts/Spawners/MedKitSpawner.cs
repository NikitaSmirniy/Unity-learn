using UnityEngine;

public class MedKitSpawner : MonoBehaviour
{
    [SerializeField] private MedKit _medKitPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            MedKit createdMedKit = Instantiate(_medKitPrefab, spawnPoint.position, Quaternion.identity);
            createdMedKit.Collected += OnCollected;
        }
    }

    private void OnCollected(MedKit medKit)
    {
        medKit.Collected -= OnCollected;
        Destroy(medKit.gameObject);
    }
}