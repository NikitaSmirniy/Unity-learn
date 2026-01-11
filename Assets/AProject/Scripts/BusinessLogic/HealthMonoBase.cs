using UnityEngine;

public class HealthMonoBase : MonoBehaviour
{
    [field: SerializeField] public Health Health { get; private set; }

    public void Init(Health health)
    {
        Health = health;
    }
}