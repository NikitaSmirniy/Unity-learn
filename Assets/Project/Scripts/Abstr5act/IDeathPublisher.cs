using System;
using UnityEngine;

public interface IDeathPublisher
{
    event Action Dead;
}