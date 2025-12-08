using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private float _recoveryRate = 0.5f;

    private AudioSource _audio;
    private Coroutine _fadeAudioCoroutine;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        
        SetDefaultValues();
    }

    public void Play()
    {
        _audio.Play();

        if (_fadeAudioCoroutine == null)
            _fadeAudioCoroutine = StartCoroutine(FadeAudio(1));
        else
        {
            StopCoroutine(_fadeAudioCoroutine);
            _fadeAudioCoroutine = StartCoroutine(FadeAudio(1));
        }
    }

    public void Stop()
    {
        if (_fadeAudioCoroutine == null)
            _fadeAudioCoroutine = StartCoroutine(FadeAudio(0, _audio.Stop));
        else
        {
            StopCoroutine(_fadeAudioCoroutine);
            _fadeAudioCoroutine = StartCoroutine(FadeAudio(0, _audio.Stop));
        }
    }

    public void SetClip(AudioClip clip)
    {
        _audio.clip = clip;
    }
    
    private IEnumerator FadeAudio(float targetVolume, Action callback = null)
    {
        while (_audio.volume != targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, _recoveryRate * Time.deltaTime);

            yield return null;
        }

        _audio.volume = targetVolume;
        _fadeAudioCoroutine = null;
        callback?.Invoke();
    }
    
    private void SetDefaultValues()
    {
        _audio.loop = true;
        _audio.playOnAwake = false;
        _audio.volume = 0;
    }
}
