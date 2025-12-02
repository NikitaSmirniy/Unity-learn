using System;
using UnityEngine;

public class WayPointsContainer
{
    private Transform[] _points;
    private int _currentNumberOfPoint;

    public event Action<Transform> Changed;

    public WayPointsContainer(Transform[] points)
    {
        _points = points;
    }

    public void Change()
    {
        if (_currentNumberOfPoint >= _points.Length - 1)
            _currentNumberOfPoint = 0;
        else
            _currentNumberOfPoint++;

        Changed?.Invoke(_points[_currentNumberOfPoint].transform);
    }
}