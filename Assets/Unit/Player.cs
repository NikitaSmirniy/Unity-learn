<<<<<<< HEAD
using Newtonsoft.Json;
=======
>>>>>>> Animation
using UnityEngine;

public class Player : Unit, IMoveable
{
<<<<<<< HEAD
    [field: SerializeField, JsonProperty("Hp")] public int Health { get; private set; }
    [field: SerializeField, JsonProperty("Arm")] public float Armor { get; private set; }

=======
>>>>>>> Animation
    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
    }
}