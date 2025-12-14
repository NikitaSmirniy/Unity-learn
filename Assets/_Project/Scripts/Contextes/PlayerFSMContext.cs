using UnityEngine;

public class PlayerFSMContext
{
    public PlayerFSMContext(float walkSpeed, float jumpForce, ObstacleCheker obstacleChker,
        AnimatorHandler animator,  Rigidbody2D rigidbody,InputService  inputService)
    {
        WalkSpeed = walkSpeed;
        JumpForce = jumpForce;
        ObstacleCheker  = obstacleChker;
        Animator = animator;
        Rigidbody = rigidbody;
        InputService = inputService;
    }

    public float WalkSpeed { get; }
    public float JumpForce { get; }
    public ObstacleCheker ObstacleCheker { get; }
    public AnimatorHandler Animator { get; }
    public Rigidbody2D Rigidbody { get; }
    public InputService InputService { get; }
}