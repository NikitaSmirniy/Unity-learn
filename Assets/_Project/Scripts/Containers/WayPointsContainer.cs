using UnityEngine;

public class WayPointsContainer
{
    private Transform[] _points;
    private int _currentIndex;

    public WayPointsContainer(Transform[] points)
    {
        _points = points;
    }

    public Transform CurrentWayPoint => _points[_currentIndex];

    public void ChangeCurrent()
    {
        _currentIndex = ++_currentIndex % _points.Length;
    }
}