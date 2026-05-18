using _Project.Code;
using UnityEngine;

public class Flag : MonoBehaviour, ITarget
{
    public bool IsSet;
    
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}