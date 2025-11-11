using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour, IControllable
{
    [SerializeField] private float _runningSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float attackRate = 2;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private AudioClip jumpAudioClip;
    [SerializeField] private AudioClip groundAudioClip;
    public bool canMove = true;

    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody;
    private bool _isRuning;
    private bool _isGrounded;
    private bool isFly;
    private bool isFlipped;
    private float nextAttackTime;

    private SpriteRenderer characterSprite;
    private CharacterAnimation _animations;
    private AttackController attackController;
    private AudioSource audio;
    private HealthManager healthManager;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        characterSprite = GetComponent<SpriteRenderer>();
        attackController = GetComponent<AttackController>();
        _animations = GetComponent<CharacterAnimation>();
        healthManager = GetComponent<HealthManager>();
        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (healthManager.health > 0)
        {
            if (Input.GetKey(KeyCode.X))
            {
                healthManager.IsBlocked = true;
            }
            else
            {
                healthManager.IsBlocked = false;
            }

            MoveInternal();
            DoGravity();

            if (Time.time >= nextAttackTime)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    _animations.AttackAnimation();
                    nextAttackTime = Time.time + 1 / attackRate;
                    //FlipCheck(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
                    //FlipCharacter(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }

            _animations.IsRuning = _isRuning;
            _animations.IsRuning = _isRuning;
            _animations.IsFlying = IsFly();
        }
        else
        {
            //healthManager.TakeDamage(0);
            gameOverPanel.SetActive(true);
        }
    }

    public void Move(Vector3 direction)
    {
        _moveDirection = direction;
    }

    private void MoveInternal()
    {
        FlipCheck(_moveDirection);

        _rigidbody.velocity = new Vector2(_moveDirection.x * _runningSpeed, _rigidbody.velocity.y);
        _isRuning = _moveDirection.x != 0 ? true : false;
    }

    private void JumpInternal()
    {
        audio.PlayOneShot(jumpAudioClip);
        _rigidbody.AddForce(transform.up * jumpForce);
    }

    private bool IsFly()
    {
        if (_rigidbody.velocity.y < 0)
            return true;
        else
            return false;
    }

    private void StopMove()
    {
        canMove = false;
    }

    private void FlipCheck(Vector2 direction)
    {
        if (direction.x > 0 && isFlipped)
        {
            FlipCharacter(direction);
        }
        else if (direction.x < 0 && !isFlipped)
        {
            FlipCharacter(direction);
        }
    }

    private void DoGravity()
    {
        float rayLenght = 0.1f;
        Vector3 rayStartPosition = transform.position + groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, rayStartPosition + Vector3.down, rayLenght, groundMask);

        if (hit.collider != null)
        {
            if (_isGrounded == false)
                audio.PlayOneShot(groundAudioClip);

            _isGrounded = hit.collider ? true : false;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void FlipCharacter(Vector2 direction)
    {
        isFlipped = !isFlipped;
        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;
        transform.localScale = flipped;

        _animations.IsRuning = _isRuning;
    }

    public void Jump()
    {
        if (_isGrounded)
            _animations.JumpAnimation();
    }
}