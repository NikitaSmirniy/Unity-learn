using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private ISoundPublisher _soundPublisher;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _soundPublisher = GetComponent<ISoundPublisher>();
    }

    private void OnEnable()
    {
        _soundPublisher.SoundPlayed += Play;
    }

    private void OnDisable()
    {
        _soundPublisher.SoundPlayed -= Play;
    }

    public void Play(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
