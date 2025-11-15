using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExplotionCubeSpawner : MonoBehaviour
{
    [SerializeField] private float _radius = 5;
    [SerializeField] private float _force = 500;

    private Exploser _exploser;
    private ColorChanger _colorChanger;
    private ScaleChanger _scaleChanger;

    public event Action Created;

    private void Awake()
    {
        _exploser = new Exploser(_radius, _force);
        _colorChanger = new ColorChanger();
        _scaleChanger = new ScaleChanger();
    }

    public void Create(ExplosionCube explotionCube)
    {
        int dividerSpawnChaceCube = 2;
        int minCountRandomCube = 2;
        int maxCountRandomCube = 6;

        int cubeSpawnCount = Random.Range(minCountRandomCube, maxCountRandomCube);

        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        for (int i = 0; i < cubeSpawnCount; i++)
        {
            var reducedSpawnChance = explotionCube.SpawnChance / dividerSpawnChaceCube;
            var newCube = Instantiate(explotionCube, explotionCube.transform.position, Quaternion.identity);

            newCube.Init(reducedSpawnChance);

            _scaleChanger.Execute(newCube);

            _colorChanger.Execute(newCube);

            rigidbodies.Add(newCube.Rigidbody);
            Created?.Invoke();
        }

        _exploser.Execute(rigidbodies);
    }
}