using UnityEngine;
using UnityEngine.Events;

public class AudioSettingsPresenter : MonoBehaviour
{
    [SerializeField]private AudioSettings _settings;
    [SerializeField]private AudioSettingsView _settingsView;

    private void OnEnable()
    {
        _settingsView.GeneralSliderEvent.AddListener(OnGeneralValueChanged());
        _settingsView.MusicSliderEven.AddListener(OnMusicValueChanged());
        _settingsView.SoundSliderEvent.AddListener(OnSoundsValueChanged());
    }

    private UnityAction<float> OnGeneralValueChanged()
    {
        return _settings.SetGeneralVolume;
    }
    
    private UnityAction<float> OnMusicValueChanged()
    {
        return _settings.SetMusicVolume;
    }
    
    private UnityAction<float> OnSoundsValueChanged()
    {
        return _settings.SetSoundsVolume;
    }
}