using UnityEngine;

public class WayPointsContainer
{
    private Transform[] _points;
    private int _currentWayPoint;

    public WayPointsContainer(Transform[] points)
    {
        _points = points;
    }

    public Transform CurrentWayPoint => _points[_currentWayPoint];

    public void ChangeCurrent()
    {
        _currentWayPoint = ++_currentWayPoint % _points.Length;
    }
}