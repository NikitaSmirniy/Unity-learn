using UnityEngine;

public class PlayerMoveHandler
{
    private float _walkSpeed;
    private float _runSpeed;
    private float _jumpForce;
    
    private TransformMover _mover;
    private KeyboardInput _keyboardInput;

    public PlayerMoveHandler(TransformMover mover, KeyboardInput keyboardInput, PlayerPreload playerPreload)
    {
        _mover = mover;
        _keyboardInput = keyboardInput;

        _walkSpeed = playerPreload.WalkSpeed;
        _runSpeed = playerPreload.RunSpeed;
        _jumpForce = playerPreload.JumpForce;
    }

    public void Walk() =>
        _mover.Move(_keyboardInput.GetAxis(), _walkSpeed * Time.fixedDeltaTime);

    public void Jump()
    {
        
        //_mover.Move(_keyboardInput.GetSpace(), _jumpForce);
    }

    public void Run()
    {
        //if (_keyboardInput.GetShift())
          //  _mover.Move(_keyboardInput.GetAxis(), _runSpeed * Time.fixedDeltaTime);
    }
}