using UnityEngine;
using Zenject;

public class MovementHandler : MonoBehaviour
{
    private IInputService _inputService;
    private IMoveable _moveable;

    [Inject]
    private void Init(IInputService inputService, IMoveable moveable)
    {
        _inputService = inputService;
        _moveable = moveable;
    }

    public void Update()
    {
        MoveByInput();
    }

    public void MoveByInput()
    {
        _moveable.Move(_inputService.GetAxis());
    }
}