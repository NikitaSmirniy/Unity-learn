using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public struct SoundInfo
{
    public AudioClip Clip;
    public AudioMixerGroup MixerGroup;
}