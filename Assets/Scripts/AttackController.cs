using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackRange = 1;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask attackMask;

    [SerializeField] private float impulseJumpForce;
    [SerializeField] private AudioClip[] missAudioClips;
    [SerializeField] private AudioClip[] hitEnemyAudioClips;
    [SerializeField] private AudioClip[] hitObsteclAudioClips;
    public int combo;

    private CharacterAnimation animations;
    private SpriteRenderer characterSprite;
    private Rigidbody2D rigidbody;
    private float maxImpulseJumpForce;
    private bool facingRight;
    private int maxCombo = 3;
    private AudioSource audio;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        characterSprite = GetComponent<SpriteRenderer>();
        animations = GetComponent<CharacterAnimation>();
        maxImpulseJumpForce = impulseJumpForce;
    }

    [SerializeField]
    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRange, attackMask);

        JumpImpulsep(attackPoint);

        combo = combo < maxCombo ? combo + 1 : 0;

        if (hit)
        {
            if (hit.TryGetComponent<HealthManager>(out HealthManager healthManager))
            {
                if (healthManager.TakeDamage(damage))
                    ShowEffects(hitEnemyAudioClips);
                else
                    ShowEffects(hitObsteclAudioClips);
            }
            else
            {
                ShowEffects(hitObsteclAudioClips);
            }
        }
        else
        {
            ShowEffects(missAudioClips);
        }
    }

    private void ShowEffects(AudioClip[] audioClips)
    {
        audio.pitch = Random.Range(0.75f, 1);
        audio.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
    }

    private void SetCombo()
    {
        combo = 0;
        animations.SetComboAnimation();
    }

    private void JumpImpulsep(Transform direction)
    {
        float multiplie = -1;

        if (transform.position.x < direction.position.x)
            multiplie = 1;
        else
            multiplie = -1;

        rigidbody.AddForce(direction.position * multiplie * impulseJumpForce);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}