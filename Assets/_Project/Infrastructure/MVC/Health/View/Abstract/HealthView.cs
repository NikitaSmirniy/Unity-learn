using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    protected Health Health;

    public void Init(Health health)
    {
        Health = health;

        Health.ValueChanged += SetValue;
        
        SetValue();
    }

    public abstract void SetValue();
}