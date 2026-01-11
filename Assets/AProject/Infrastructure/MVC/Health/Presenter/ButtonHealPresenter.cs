using System;

public class ButtonHealPresenter : IDisposable
{
    private Healer _healer;
    private ButtonView _buttonView;

    public ButtonHealPresenter(Healer healer, ButtonView buttonView)
    {
        _healer = healer;
        _buttonView = buttonView;

        _buttonView.Clicked += _healer.Heal;
    }

    public void Dispose()
    {
        _buttonView.Clicked -= _healer.Heal;
    }
}