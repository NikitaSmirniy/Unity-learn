using UnityEngine;

public class RandomWayPointsGenerator
{
    private const string WayPointName = "WayPoint";
    private const string WayPointsContainerName = "WayPointsContainer";

    public Transform[] Generate(int minNumberOfWayPoints, int maxNumberOfWayPoints, float minPointGenerationCoordinate,
        float maxPointGenerationCoordinate)
    {
        var numberOfPoints = Random.Range(minNumberOfWayPoints, maxNumberOfWayPoints);

        var wayPoints = new Transform[numberOfPoints];

        var wayPointsContainer = new GameObject(WayPointsContainerName);

        for (int i = 0; i < wayPoints.Length; i++)
        {
            var createdWayPoint = new GameObject($"{WayPointName} - {i + 1}");
            createdWayPoint.transform.SetParent(wayPointsContainer.transform);

            createdWayPoint.transform.position =
                new Vector3(Random.Range(minPointGenerationCoordinate, maxPointGenerationCoordinate),
                    Random.Range(minPointGenerationCoordinate, maxPointGenerationCoordinate),
                    Random.Range(minPointGenerationCoordinate, maxPointGenerationCoordinate));

            wayPoints[i] = createdWayPoint.transform;
        }

        return wayPoints;
    }
}