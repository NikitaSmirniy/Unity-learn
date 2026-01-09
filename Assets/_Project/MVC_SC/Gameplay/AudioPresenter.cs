using System;
using UnityEngine;

namespace AudioMixer
{
    public class AudioPresenter : MonoBehaviour
    {
        [SerializeField] private AudioPlayer _audioPlayer;
        [SerializeField] private ButtonsView buttonsView;
        [SerializeField] private AudioClipsContainer _audioClipsContainer;

        private void OnEnable()
        {
            buttonsView.HealButton.AddListener(OnHealButtonClicked);
            buttonsView.CoinButtonClicked.AddListener(OnCoinButtonClicked);
            buttonsView.DeathButtonClicked.AddListener(OnDeathButtonClicked);
        }

        private void OnDisable()
        {
            buttonsView.HealButton.RemoveListener(OnHealButtonClicked);
            buttonsView.CoinButtonClicked.RemoveListener(OnCoinButtonClicked);
            buttonsView.DeathButtonClicked.RemoveListener(OnDeathButtonClicked);
        }

        private void OnHealButtonClicked() =>
            _audioPlayer.Play(_audioClipsContainer.HealClip);

        private void OnCoinButtonClicked() =>
            _audioPlayer.Play(_audioClipsContainer.CoinClip);

        private void OnDeathButtonClicked() =>
            _audioPlayer.Play(_audioClipsContainer.DeathClip);
    }
}