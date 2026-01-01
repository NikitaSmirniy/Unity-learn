using UnityEngine;

namespace AudioMixer
{
    public class AudioClipsContainer : MonoBehaviour
    {
        [SerializeField] private AudioClip _healClip;
        [SerializeField] private AudioClip _coinClip;
        [SerializeField] private AudioClip _deathClip;

        public AudioClip HealClip => _healClip;
        public AudioClip CoinClip => _coinClip;
        public AudioClip DeathClip => _deathClip;
    }
}