using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorHandler : MonoBehaviour
{
    private const string SpeedAnimatorParameter = "Speed";
    private const string JumpAnimatorParameter = "Jump";
    private const string FallAnimatorParameter = "Falling";
    private const string AttackAnimatorParameter = "Attack";
    private const string IsDeathAnimatorParameter = "IsDeath";
    private const string DeathAnimatorParameter = "Death";

    private readonly int Speed = Animator.StringToHash(SpeedAnimatorParameter);
    private readonly int Jump = Animator.StringToHash(JumpAnimatorParameter);
    private readonly int Falling = Animator.StringToHash(FallAnimatorParameter);
    private readonly int Attack = Animator.StringToHash(AttackAnimatorParameter);
    private readonly int IsDeath = Animator.StringToHash(IsDeathAnimatorParameter);
    private readonly int Death = Animator.StringToHash(DeathAnimatorParameter);

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

    public void PlayAttack() =>
        _animator.SetTrigger(Attack);

    public void SetMove(float speed) =>
        _animator.SetFloat(Speed, speed);

    public void PlayDeath()
    {
        _animator.SetBool(IsDeath, true);
        _animator.SetTrigger(Death);
    }
}