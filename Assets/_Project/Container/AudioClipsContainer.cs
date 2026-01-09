using UnityEngine;

namespace AudioMixer
{
    [CreateAssetMenu(fileName = "New Audio Clip Container", menuName = "Audio Clip Container", order = 51)]
    public class AudioClipsContainer : ScriptableObject
    {
        [SerializeField] private AudioClip _healClip;
        [SerializeField] private AudioClip _coinClip;
        [SerializeField] private AudioClip _deathClip;

        public AudioClip HealClip => _healClip;
        public AudioClip CoinClip => _coinClip;
        public AudioClip DeathClip => _deathClip;
    }
}