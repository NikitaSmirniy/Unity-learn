using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class ExplosionCube : MonoBehaviour
{
    public int SpawnChance { get; private set; } = 100;
    public bool IsDying { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Renderer Renderer { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }

    public void Die()
    {
        IsDying = true;
        Destroy(gameObject);
    }

    public void Init(int spawnChance)
    {
        SpawnChance = spawnChance;
    }
}