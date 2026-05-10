using System;
using _Project.Code;

public class BaseItemAmountPresenter : IDisposable
{
    private AmountView _view;
    private Base _base;

    public BaseItemAmountPresenter(AmountView view, Base @base)
    {
        _view = view;
        _base = @base;
    }

    public void Enable()
    {
        _base.ItemAmountChanged += _view.SetAmount;
    }

    public void Dispose()
    {
        _base.ItemAmountChanged -= _view.SetAmount;
    }
}