using Newtonsoft.Json;
using UnityEngine;

public class Player : Unit, IMoveable
{
    [field: SerializeField, JsonProperty("Hp")] public int Health { get; private set; }
    [field: SerializeField, JsonProperty("Arm")] public float Armor { get; private set; }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
    }
}