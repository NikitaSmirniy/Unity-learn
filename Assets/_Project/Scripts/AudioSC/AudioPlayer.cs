using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        
        SetDefaultValues();
    }

    public void Play(AudioClip clip)
    {
        _audio.PlayOneShot(clip);
    }
    
    private void SetDefaultValues()
    {
        _audio.playOnAwake = false;
    }
}
