using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioMixerGroups.asset", menuName = "AudioMixerGroups", order = 51)]
public class AudioMixerGroups : ScriptableObject
{
    [SerializeField] private AudioMixerGroup _masterMixerGroup;
    [SerializeField] private AudioMixerGroup _musicMixerGroup;
    [SerializeField] private AudioMixerGroup _viewMixerGroup;

    public AudioMixerGroup MasterMixerGroup => _masterMixerGroup;
    public AudioMixerGroup MusicMixerGroup =>  _musicMixerGroup;
    public AudioMixerGroup ViewMixerGroup => _viewMixerGroup;
}