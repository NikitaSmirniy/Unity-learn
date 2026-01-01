using System;
using UnityEngine;

public abstract class BaseScreen : MonoBehaviour
{
    public abstract Type ModelType { get; }

    public abstract void Show();
    public abstract void Close();
    public abstract void Bind(object model);

    public virtual void Dispose()
    {
    }
}