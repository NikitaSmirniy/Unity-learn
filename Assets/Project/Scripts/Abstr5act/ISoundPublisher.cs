using System;
using UnityEngine;

public interface ISoundPublisher
{
    event Action<AudioClip> SoundPlayed;
}