using System;
using UnityEngine;

[Serializable]
public class PlayerPreload
{
    [field: SerializeField] public float WalkSpeed { get; private set; }
    [field: SerializeField] public float RunSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
}