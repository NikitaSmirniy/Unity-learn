using UnityEngine;

namespace AudioMixer
{
    public class AudioPresenter : MonoBehaviour
    {
        [SerializeField] private AudioPlayer _audioPlayer;
        [SerializeField] private AudioButtonsView buttonsView;
        [SerializeField] private AudioClipsContainer _audioClipsContainer;

        private void OnEnable()
        {
            buttonsView.HealButtonClicked.AddListener(OnHealButtonClicked);
            buttonsView.CoinButtonClicked.AddListener(OnCoinButtonClicked);
            buttonsView.DeathButtonClicked.AddListener(OnDeathButtonClicked);
        }

        private void OnHealButtonClicked() =>
            _audioPlayer.Play(_audioClipsContainer.HealClip);

        private void OnCoinButtonClicked() =>
            _audioPlayer.Play(_audioClipsContainer.CoinClip);

        private void OnDeathButtonClicked() =>
            _audioPlayer.Play(_audioClipsContainer.DeathClip);
    }
}