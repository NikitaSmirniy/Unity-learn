using System;
using UnityEngine;

public class CharacterInputContoller : MonoBehaviour
{
    private IControllable _controllable;

    private void Awake()
    {
        _controllable = GetComponent<IControllable>();

        if (_controllable == null)
            throw new Exception($"Error {gameObject.name}");
    }

    private void Update()
    {
        ReadMove();
        ReadJump();
    }

    private void ReadMove()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var direction = new Vector2(horizontal, 0);

        _controllable.Move(direction);
    }

    private void ReadJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _controllable.Jump();
        }
    }
}