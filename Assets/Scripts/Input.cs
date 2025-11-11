using UnityEngine;

namespace Scripts
{
    public static class Input
    {
        private readonly static IInputService _inputService = new KeyBoardInput();

        public static Vector2 GetAxis() => _inputService.GetAxis();
    }
}