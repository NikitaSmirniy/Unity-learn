using UnityEngine;
using UnityEngine.Audio;

public class SliderVolumeHandler
{
    private const int MinGeneralVolume = -80;

    private AudioMixerGroup _mixerGroup;

    public SliderVolumeHandler(AudioMixerGroup mixerGroup)
    {
        _mixerGroup = mixerGroup;
    }

    public void SetVolume(float volume)
    {
        if (volume == 0)
            _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, MinGeneralVolume);
        else
            _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, Mathf.Log10(volume) * 20);
    }
}