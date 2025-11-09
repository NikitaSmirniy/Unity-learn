using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] private float maxHealth = 100;

    private CharacterAnimation animations;
    private Collider2D collider;
    private Rigidbody2D rigidbody;
    public bool IsBlocked { private get; set; }
    public bool isDead;

    private void Start()
    {
        animations = GetComponent<CharacterAnimation>();
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    private void Protect()
    {
        animations.IsBlocked = IsBlocked;
    }

    public bool TakeDamage(int damage)
    {
        if (IsBlocked == false)
        {
            health -= damage;
            animations.Hurt();

            if (health <= 0)
            {
                rigidbody.isKinematic = true;
                collider.enabled = false;
                collider.isTrigger = true;
                isDead = true;
                animations.DeadAnimation();
            }

            return true;
        }
        else
        {
            Protect();
            return false;
        }
    }

    public void SetProtect()
    {
        animations.IsBlocked = false;
    }
}