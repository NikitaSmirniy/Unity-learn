using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;

public class SplineFolower : MonoBehaviour
{
    [SerializeField] private Spline _spline;
    [SerializeField] private float _speed;
    [SerializeField] private float _sensitivity;

    private float _splineRate;
    private float _input;
    private float _lastMousePosition;

    private void Start()
    {
        _lastMousePosition = Input.mousePosition.x;
    }

    private void Update()
    {
        _input += (Input.mousePosition.x - _lastMousePosition) * _sensitivity;
        _lastMousePosition = Input.mousePosition.x;
        _input = Mathf.Clamp(_input, -1,1);
        
        _splineRate += _speed * Time.deltaTime;

        if (_splineRate <= _spline.nodes.Count - 1)
            Place();
        else
        {
            _splineRate = 0;
        }
    }

    private void Place()
    {
        CurveSample sample = _spline.GetSample(_splineRate);

        transform.localPosition = sample.location + Vector3.right * _input;
        transform.localRotation = sample.Rotation;
    }
}