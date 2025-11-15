using UnityEngine;

public class RandomChanceGenerator
{
    public int Execute()
    {
        int maxRandomChance = 100;

        return Random.Range(0, maxRandomChance);
    }
}