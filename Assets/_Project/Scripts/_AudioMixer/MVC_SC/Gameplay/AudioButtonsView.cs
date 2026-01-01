using UnityEngine;
using UnityEngine.UI;

namespace AudioMixer
{
    public class AudioButtonsView : MonoBehaviour
    {
        [SerializeField] private Button _healButton;
        [SerializeField] private Button _coinButton;
        [SerializeField] private Button _deathButton;

        public Button.ButtonClickedEvent HealButtonClicked => _healButton.onClick;
        public Button.ButtonClickedEvent CoinButtonClicked => _coinButton.onClick;
        public Button.ButtonClickedEvent DeathButtonClicked => _deathButton.onClick;
    }
}