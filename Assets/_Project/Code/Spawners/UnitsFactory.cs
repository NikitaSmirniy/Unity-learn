using System.Collections.Generic;
using _Project.Code;
using UnityEngine;

public class UnitsFactory
{
    private Unit _prefab;
    private Transform _baseTransform;

    public UnitsFactory(Unit prefab, Transform baseTransform)
    {
        _prefab = prefab;
        _baseTransform = baseTransform;
    }

    public List<Unit> Generate(int count, Transform spawnPoint)
    {
        List<Unit> units = new List<Unit>();

        for (int i = 0; i < count; i++)
        {
            Unit newUnit = Object.Instantiate(_prefab, new Vector3(spawnPoint.position.x,0,spawnPoint.position.z + i), Quaternion.identity);
            
            newUnit.Init(_baseTransform);
            
            units.Add(newUnit);
        }

        return units;
    }
}