using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraightCommand : MoveCommand
{
    public MoveStraightCommand(Transform transform, float stepDistance) : base(transform, stepDistance) { }

    public override void Execute()
    {
        _transform.position += Vector3.right * _stepDistance;
    }

    public override void Undo()
    {
        _transform.position -= Vector3.right * _stepDistance;
    }
}