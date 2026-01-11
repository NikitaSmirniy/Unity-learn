using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudioClipsPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _stepClip;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _landClip;
    [SerializeField] private AudioClip _attackClip;
    [SerializeField] private AudioClip _deathClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayStepClip() => _audioSource.PlayOneShot(_stepClip);

    public void PlayJumpClip() => _audioSource.PlayOneShot(_jumpClip);

    public void PlayLandClip() => _audioSource.PlayOneShot(_landClip);

    public void PlayAttackClip() => _audioSource.PlayOneShot(_attackClip);
    
    public void PlayDeathClip() => _audioSource.PlayOneShot(_deathClip);
}