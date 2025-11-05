using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveCommand 
{
    protected Transform _transform;
    protected float _stepDistance;

    public MoveCommand(Transform transform, float stepDistance = 1f)
    {
        _transform = transform;
        _stepDistance = stepDistance;
    }

    public abstract void Execute();
    public abstract void Undo();
}