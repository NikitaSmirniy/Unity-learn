using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsView : MonoBehaviour
{
    [SerializeField] private Slider _geniralSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;
    
    public Slider.SliderEvent GeneralSliderEvent => _geniralSlider.onValueChanged;
    public Slider.SliderEvent MusicSliderEven => _musicSlider.onValueChanged;
    public Slider.SliderEvent SoundSliderEvent => _soundSlider.onValueChanged;
}