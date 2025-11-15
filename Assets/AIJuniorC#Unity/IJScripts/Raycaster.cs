using System;
using UnityEngine;

public class Raycaster : IDisposable
{
    private float _rayRange = 50;
    private InputReader _reader;

    public event Action<ExplosionCube> CubeFound;

    public Raycaster(InputReader reader)
    {
        _reader = reader;
        _reader.Clicked += Cast;
    }

    public void Dispose() =>
        _reader.Clicked -= Cast;

    private void Cast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayRange) &&
            hit.collider.gameObject.TryGetComponent<ExplosionCube>(out ExplosionCube explotionCube))
            CubeFound?.Invoke(explotionCube);
    }
}