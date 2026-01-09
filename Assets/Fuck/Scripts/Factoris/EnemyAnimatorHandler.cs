using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimatorHandler : MonoBehaviour
{
    private const string AttackAnimatorParameter = "Attack";
    private const string ChaseAnimatorParameter = "Chase";
    private const string PatrollAnimatorParameter = "Patroll";
    private const string DeathAnimatorParameter = "Death";

    private readonly int Attack = Animator.StringToHash(AttackAnimatorParameter);
    private readonly int Chase = Animator.StringToHash(ChaseAnimatorParameter);
    private readonly int Patroll = Animator.StringToHash(PatrollAnimatorParameter);
    private readonly int Death = Animator.StringToHash(DeathAnimatorParameter);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAttack() =>
        _animator.SetTrigger(Attack);

    public void PlayChase() =>
        _animator.SetTrigger(Chase);

    public void PlayPatroll() =>
        _animator.SetTrigger(Patroll);

    public void PlayDeath() =>
        _animator.SetTrigger(Death);
}