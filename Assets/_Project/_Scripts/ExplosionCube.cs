using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class ExplosionCube : MonoBehaviour
{
    public int SpawnChance { get; private set; } = 100;
    public float Radius { get; private set; } = 5;
    public float Force { get; private set; } = 100;
    public bool IsDying { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Renderer Renderer { get; private set; }

    private Recalculater _recalculater;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
        _recalculater = new();
    }

    public void Die()
    {
        IsDying = true;
        Destroy((gameObject));
    }

    public void Init(int spawnChance)
    {
        SpawnChance = spawnChance;
        var scale = transform.localScale.sqrMagnitude;
        Force = _recalculater.RecalculateValue(Force, 1f / scale);
        Radius = _recalculater.RecalculateValue(Radius, 1f / scale);
    }
}