using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [Header("Spawners")] 
    
    [SerializeField] private Spawner[] _spawners;
    
    [Header("Citizen Creator Values")]
    
    [SerializeField]private Citizen _citizenPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CitizenPreload _citizenPreload;

    private CitizenCreator _citizenCreator;

    private void Start()
    {
        _citizenCreator = new CitizenCreator(_citizenPrefab, _citizenPreload, new RandomWayPointsGenerator());

        for (int i = 0; i < _spawners.Length; i++)
        {
            var createdCitizen = _citizenCreator.Create();
            Spawner currentSpawner = _spawners[i];

            currentSpawner.Init(createdCitizen.transform);

            currentSpawner.StartSpawning();
        }
    }
}