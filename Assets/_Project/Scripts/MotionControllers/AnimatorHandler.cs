using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorHandler : MonoBehaviour
{
    private const string SpeedAnimatorParameter = "Speed";

    private readonly int Speed = Animator.StringToHash(SpeedAnimatorParameter);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimation(float speed) =>
        _animator.SetFloat(Speed, speed);
}