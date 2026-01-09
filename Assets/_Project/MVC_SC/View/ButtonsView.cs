using UnityEngine;
using UnityEngine.UI;

namespace AudioMixer
{
    public class ButtonsView : MonoBehaviour
    {
        [SerializeField] private Button _healButton;
        [SerializeField] private Button _coinButton;
        [SerializeField] private Button _deathButton;

        public Button.ButtonClickedEvent HealButton => _healButton.onClick;
        public Button.ButtonClickedEvent CoinButtonClicked => _coinButton.onClick;
        public Button.ButtonClickedEvent DeathButtonClicked => _deathButton.onClick;
    }
}