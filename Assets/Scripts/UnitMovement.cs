using UnityEngine;

namespace Scripts
{
    public class UnitMovement : MonoBehaviour
    {
        private IMoveable _moveable;

        private void Start()
        {
            _moveable = GetComponent<IMoveable>();
        }

        private void Update()
        {
            MoveByInput();
        }

        private void MoveByInput()
        {
            _moveable.Move(Input.GetAxis());
        }
    }
}