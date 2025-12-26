using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorHandler : MonoBehaviour
{
    private const string SpeedAnimatorParameter = "Speed";
    private const string JumpAnimatorParameter = "Jump";
    private const string FallAnimatorParameter = "Falling";

    private readonly int Speed = Animator.StringToHash(SpeedAnimatorParameter);
    private readonly int Jump = Animator.StringToHash(JumpAnimatorParameter);
    private  readonly int Falling = Animator.StringToHash(FallAnimatorParameter);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayJump() =>
        _animator.SetBool(Jump, true);

    public void StopJump() =>
        _animator.SetBool(Jump, false);
    
    public void PlayFalling(int isFalling) =>
        _animator.SetInteger(Falling, isFalling);

    public void SetMove(float speed) =>
        _animator.SetFloat(Speed, speed);
}