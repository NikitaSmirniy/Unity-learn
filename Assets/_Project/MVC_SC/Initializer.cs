using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Initializer : MonoBehaviour
{
    [SerializeField] private AudioMixerGroups _audioMixerGroups;
    [SerializeField] private List<SliderView> _sliderViews;
    [SerializeField] private ToggleView _toggleView;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SliderVolumeHandler masterSlider = CreateSliderVolumeHandler(_audioMixerGroups.MasterMixerGroup);
        SliderVolumeHandler musicSlider = CreateSliderVolumeHandler(_audioMixerGroups.MusicMixerGroup);
        SliderVolumeHandler viewSlider = CreateSliderVolumeHandler(_audioMixerGroups.ViewMixerGroup);

        List<SliderVolumeHandler> sliderHandlers = new List<SliderVolumeHandler>()
            { masterSlider, musicSlider, viewSlider };

        var audioSlidersPresenter = new SlidersPresenter(_sliderViews, sliderHandlers, _toggleView);

        ToggleVolumeHandler masterToggle = CreateToggleVolumeHandler(_audioMixerGroups.MasterMixerGroup);

        var togglePresenter = new TogglePresenter(_toggleView, masterToggle);
    }

    private SliderVolumeHandler CreateSliderVolumeHandler(AudioMixerGroup audioMixerGroup)
    {
        return new SliderVolumeHandler(audioMixerGroup);
    }

    private ToggleVolumeHandler CreateToggleVolumeHandler(AudioMixerGroup audioMixerGroup)
    {
        return new ToggleVolumeHandler(audioMixerGroup);
    }
}