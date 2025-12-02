using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [Header("Spawners")] [SerializeField] private Spawner[] _spawners;

    [Header("Citizen Creator Values")] [SerializeField]
    private Citizen _citizenPrefab;

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private int _minNumberOfWayPoints = 3;
    [SerializeField] private int _maxNumberOfWayPoints = 7;
    [SerializeField] private int _minPointGenerationCoordinate = -10;
    [SerializeField] private int _maxPointGenerationCoordinate = 10;
    [SerializeField] private int _minSpawnPosOfCitizen = -10;
    [SerializeField] private int _maxSpawnPosOfCitizen = 10;

    private CitizenCreator _citizenCreator;

    private void Start()
    {
        _citizenCreator = new CitizenCreator(_citizenPrefab, _minNumberOfWayPoints, _maxNumberOfWayPoints,
            _minPointGenerationCoordinate, _maxPointGenerationCoordinate, _minSpawnPosOfCitizen,
            _maxSpawnPosOfCitizen, new RandomWayPointsGenerator());

        for (int i = 0; i < _spawners.Length; i++)
        {
            var createdCitizen = _citizenCreator.Create();
            var currentSpawner = Instantiate(_spawners[i]);

            currentSpawner.Init(createdCitizen.transform);

            currentSpawner.StartSpawning();
        }
    }
}