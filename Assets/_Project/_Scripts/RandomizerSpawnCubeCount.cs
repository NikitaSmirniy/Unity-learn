using UnityEngine;

public class RandomizerSpawnCubeCount
{
    public int Execute(int minCountRandomCube = 2,int maxCountRandomCube = 6) => Random.Range(minCountRandomCube, maxCountRandomCube);
}