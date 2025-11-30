using UnityEngine;

public class RandomDirectionGenerator
{
    public Vector3 Generate(float minRangeOfMotion = -1, float maxRangeOfMotion = 1)
    {
        var newDirection = new Vector3(Random.Range(minRangeOfMotion, maxRangeOfMotion),
            Random.Range(minRangeOfMotion, maxRangeOfMotion),
            Random.Range(minRangeOfMotion, maxRangeOfMotion));
    
        return newDirection;
    }
}