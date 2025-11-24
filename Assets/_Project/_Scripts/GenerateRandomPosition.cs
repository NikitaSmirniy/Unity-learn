using UnityEngine;

public class GenerateRandomPosition
{
    public Vector3 Generate()
    {
        var rX = Random.Range(-5, 5);
        var rZ = Random.Range(-5, 5);
        var rY = Random.Range(-5, 5);

        return new Vector3(rX, rZ, rY);
    }
}