using UnityEngine;

public class ExplotionCubeSpawner : MonoBehaviour
{
    private ColorChanger _colorChanger;
    private ScaleChanger _scaleChanger;

    private void Awake()
    {
        _colorChanger = new ColorChanger();
        _scaleChanger = new ScaleChanger();
    }

    public ExplosionCube Create(ExplosionCube explotionCube)
    {
        int dividerSpawnChaceCube = 2;

        var reducedSpawnChance = explotionCube.SpawnChance / dividerSpawnChaceCube;
        var newCube = Instantiate(explotionCube, explotionCube.transform.position, Quaternion.identity);

        _scaleChanger.Execute(newCube.transform);

        _colorChanger.Execute(newCube);

        newCube.Init(reducedSpawnChance);

        return newCube;
    }
}