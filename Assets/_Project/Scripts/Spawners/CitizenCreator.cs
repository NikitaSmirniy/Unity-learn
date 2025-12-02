using UnityEngine;

public class CitizenCreator
{
    private Citizen _prefab;
    private int _minNumberOfWayPoints = 3;
    private int _maxNumberOfWayPoints = 7;
    private int _minPointGenerationCoordinate = -10;
    private int _maxPointGenerationCoordinate = 10;
    private int _minSpawnPosOfCitizen = -10;
    private int _maxSpawnPosOfCitizen = 10;

    private RandomWayPointsGenerator _generator;

    public CitizenCreator(Citizen prefab, int minNumberOfWayPoints, int maxNumberOfWayPoints,
        int minPointGenerationCoordinate, int maxPointGenerationCoordinate, int minSpawnPosOfCitizen,
        int maxSpawnPosOfCitizen,
        RandomWayPointsGenerator generator)
    {
        _prefab = prefab;
        _minNumberOfWayPoints = minNumberOfWayPoints;
        _maxNumberOfWayPoints = maxNumberOfWayPoints;
        _minPointGenerationCoordinate = minPointGenerationCoordinate;
        _maxPointGenerationCoordinate = maxPointGenerationCoordinate;
        _minSpawnPosOfCitizen = minSpawnPosOfCitizen;
        _maxSpawnPosOfCitizen = maxSpawnPosOfCitizen;
        _generator = generator;
    }

    public Citizen Create()
    {
        var createdCitizen = Object.Instantiate(_prefab,
            new Vector3(Random.Range(_minSpawnPosOfCitizen, _maxSpawnPosOfCitizen),
                Random.Range(_minSpawnPosOfCitizen, _maxSpawnPosOfCitizen)), Quaternion.identity);

        var randomWayPoints = _generator.Generate(_minNumberOfWayPoints, _maxNumberOfWayPoints,
            _minPointGenerationCoordinate, _maxPointGenerationCoordinate);

        createdCitizen.Init(randomWayPoints);

        return createdCitizen;
    }
}