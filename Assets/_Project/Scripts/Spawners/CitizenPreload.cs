using System;
using UnityEngine;

[Serializable]
public struct CitizenPreload
{
    [field: SerializeField] public int MinNumberOfWayPoints { get; private set; }
    [field: SerializeField] public int MaxNumberOfWayPoints { get; private set; }
    [field: SerializeField] public int MinPointGenerationCoordinate { get; private set; }
    [field: SerializeField] public int MaxPointGenerationCoordinate { get; private set; }
    [field: SerializeField] public int MinSpawnPosOfCitizen { get; private set; }
    [field: SerializeField] public int MaxSpawnPosOfCitizen { get; private set; }
}