using UnityEngine;

namespace AudioMixer
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Play(AudioClip clip) => _audioSource.PlayOneShot(clip);
    }
}