using UnityEngine.Audio;

public abstract class VolumeHandler
{
    protected const int MinGeneralVolume = -80;

    protected AudioMixerGroup _mixerGroup;

    public VolumeHandler(AudioMixerGroup mixerGroup)
    {
        _mixerGroup = mixerGroup;
    }

    public abstract void SetVolume(float volume);
}