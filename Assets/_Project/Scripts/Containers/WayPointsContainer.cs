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
        _currentNumberOfPoint = ++_currentNumberOfPoint % _points.Length;
        
        Changed?.Invoke(_points[_currentNumberOfPoint].transform);
    }
}