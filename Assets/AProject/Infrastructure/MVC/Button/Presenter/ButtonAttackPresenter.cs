using System;

public class ButtonAttackPresenter : IDisposable
{
    private Attackeer _attackeer;
    private ButtonView _buttonView;

    public ButtonAttackPresenter(Attackeer attackeer, ButtonView buttonView)
    {
        _attackeer = attackeer;
        _buttonView = buttonView;

        _buttonView.Clicked += _attackeer.Attack;
    }

    public void Dispose()
    {
        _buttonView.Clicked -= _attackeer.Attack;
    }
}