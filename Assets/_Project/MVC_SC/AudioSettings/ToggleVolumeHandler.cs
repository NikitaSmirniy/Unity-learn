using UnityEngine;
using UnityEngine.Audio;

public class ToggleVolumeHandler
{
    private const int MinGeneralVolume = -80;

    private AudioMixerGroup _mixerGroup;
    private float _lastValueSound;

    public ToggleVolumeHandler(AudioMixerGroup mixerGroup)
    {
        _mixerGroup = mixerGroup;
    }

    public void SetIsOnGeneral(bool isOn)
    {
        if (isOn == false)
        {
            var currentVolume = _mixerGroup.audioMixer.GetFloat(_mixerGroup.name, out var value);
            _lastValueSound = value;

            SetVolume(MinGeneralVolume);
        }
        else
        {
            SetVolume(_lastValueSound);
        }
    }

    private void SetVolume(float volume) =>
        _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, volume);
}