using UnityEngine;

public class RandomChanceGenerator
{
    public int GetRandomChance()
    {
        int maxRandomChance = 100;

        return Random.Range(0, maxRandomChance);
    }
}