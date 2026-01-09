using System.Collections.Generic;

public class SlidersPresenter
{
    private List<SliderView> _sliderViews ;
    private List<SliderVolumeHandler> _volumeHandlers;
    private ToggleView _toggleView;

    public SlidersPresenter(List<SliderView> sliderViews, List<SliderVolumeHandler> volumeHandlers,  ToggleView toggleView)
    {
        _sliderViews = sliderViews;
        _volumeHandlers = volumeHandlers;
        _toggleView = toggleView;

        for (int i = 0; i < _sliderViews.Count; i++)
        {
            _sliderViews[i].SliderEvent.AddListener(_volumeHandlers[i].SetVolume);
            _sliderViews[i].SliderEvent.AddListener(_toggleView.SetAsActive);
        }
    }
}