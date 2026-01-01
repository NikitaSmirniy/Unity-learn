using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    private const string GeneralVolume = "GeneralVolume";
    private const string MusicVolume = "MusicVolume";
    private const string SoundsVolume = "SoundsVolume";
    
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    public void SetGeneralVolume(float volume) =>
        _audioMixerGroup.audioMixer.SetFloat(GeneralVolume, Mathf.Log10(volume) * 20);
    
    public void SetMusicVolume(float volume) =>
        _audioMixerGroup.audioMixer.SetFloat(MusicVolume, Mathf.Log10(volume) * 20);
    
    public void SetSoundsVolume(float volume) =>
        _audioMixerGroup.audioMixer.SetFloat(SoundsVolume, Mathf.Log10(volume) * 20);
}