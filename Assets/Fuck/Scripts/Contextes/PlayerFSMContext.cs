using UnityEngine;

public struct PlayerFSMContext
{
    public PlayerFSMContext(float walkSpeed, float jumpForce, ObstacleCheker obstacleChker,
        PlayerAnimatorHandler playerAnimator, Rigidbody2D rigidbody, InputService inputService, Mover mover,
        Health health)
    {
        WalkSpeed = walkSpeed;
        JumpForce = jumpForce;
        ObstacleCheker = obstacleChker;
        PlayerAnimator = playerAnimator;
        Rigidbody = rigidbody;
        InputService = inputService;
        Mover = mover;
        Health = health;
    }

    public float WalkSpeed { get; }
    public float JumpForce { get; }
    public ObstacleCheker ObstacleCheker { get; }
    public PlayerAnimatorHandler PlayerAnimator { get; }
    public Rigidbody2D Rigidbody { get; }
    public InputService InputService { get; }
    public Mover Mover { get; }
    public Health Health  { get; }
}