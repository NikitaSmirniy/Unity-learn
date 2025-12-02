using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class NPC : MonoBehaviour
{
    protected MoverHandler _moverHandler;

    private void Awake()
    {
        SetDefaultValues();
    }

    public void Init(Vector3 startPosition, Transform target)
    {
        transform.position = startPosition;
        _moverHandler.SetTarget(target);
    }
    
    public virtual void SetDefaultValues(){}
}