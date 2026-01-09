public class TogglePresenter
{
    private ToggleView _toggleView;
    private ToggleVolumeHandler _toggleVolumeHandler;

    public TogglePresenter(ToggleView toggleView, ToggleVolumeHandler toggleVolumeHandler)
    {
        _toggleView = toggleView;
        _toggleVolumeHandler = toggleVolumeHandler;

        _toggleView.ToggleEvent.AddListener(_toggleVolumeHandler.SetIsOnGeneral);
    }
}