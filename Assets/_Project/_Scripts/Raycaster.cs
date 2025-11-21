using System;
using UnityEngine;

public class Raycaster : IDisposable, IInitializable
{
    private float _rayRange = 50;
    private InputReader _reader;

    public event Action<ExplosionCube> CubeFound;

    public Raycaster(InputReader reader)
    {
        _reader = reader;
    }

    public void Dispose() =>
        _reader.Clicked -= Cast;

    private void Cast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayRange) &&
            hit.collider.TryGetComponent<ExplosionCube>(out ExplosionCube resource))
            CubeFound?.Invoke(resource);
    }

    public void Initialize()
    {
        _reader.Clicked += Cast;
    }
}