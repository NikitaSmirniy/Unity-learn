using System;
using _Project.Code;
using UnityEngine;

public class BaseColonisationHandler : IDisposable
{
    private readonly MonoObjectsSelector _monoObjectsSelector;
    private readonly InputService _inputService;

    private Base _selected;

    public BaseColonisationHandler(MonoObjectsSelector monoObjectsSelector, InputService inputService)
    {
        _monoObjectsSelector = monoObjectsSelector;
        _inputService = inputService;

        _inputService.LeftMouseButtonDown += OnLeftMouseButtonDown;
    }

    public void Dispose()
    {
        _inputService.LeftMouseButtonDown -= OnLeftMouseButtonDown;
    }

    private void OnLeftMouseButtonDown()
    {
        if (_monoObjectsSelector.TrySelect(out Base selected))
        {
            if (_selected != null && _selected == selected)
            {
                _selected = null;
            }
            else
            {
                _selected = selected;
            }

            return;
        }

        if (_selected != null)
        {
            if (_monoObjectsSelector.TrySelect(out Ground _, out RaycastHit hit))
            {
                _selected.SetFlagToBuildingNewBase(hit.point);

                _selected = null;

                return;
            }

            if (_selected.Flag == hit.collider.TryGetComponent(out Flag _))
            {
                _selected.TryRemoveBuilding();
            }
        }
    }
}