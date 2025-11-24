using UnityEngine;

public class LiveTimeGenerator
{
    public float Generate(float min = 2, int max = 5) => Random.Range(min, max);
}