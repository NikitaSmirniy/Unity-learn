using System;
using UnityEngine;

public interface IGameOverPublisher
{
    event Action<GameObject> GameOver;
}