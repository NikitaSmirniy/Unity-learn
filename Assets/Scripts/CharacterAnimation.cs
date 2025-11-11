using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    public bool IsRuning { get;  set; }
    public bool IsFlying { get;  set; }
    public bool IsBlocked { get;  set; }

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsRunning", IsRuning);
        animator.SetBool("IsFlying", IsFlying);
    }

    public void AttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public void Hurt()
    {
        animator.SetTrigger("Hurt");
    }

    public void SetComboAnimation()
    {
        animator.SetInteger("Attack", 0);
    }

    public void DeadAnimation()
    {
        IsRuning = false;
        IsRuning = false;
        IsFlying = false;
        animator.SetInteger("Dead", 1);
    }

    public void ProtectAnimation()
    {
        animator.SetBool("IsBlocked", IsBlocked);
    }

    public void JumpAnimation()
    {
        animator.SetTrigger("Jump");
    }
}