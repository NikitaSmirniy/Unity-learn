using UnityEngine;

public abstract class View : MonoBehaviour
{
    protected IHealthModel _model;

    private void OnEnable()
    {
        if (_model != null)
            _model.ValueChanged += OnModelValueChanged;
    }

    private void OnDisable()
    {
        if (_model != null)
            _model.ValueChanged -= OnModelValueChanged;
    }

    public void SetModel(IHealthModel model)
    {
        if (_model != null)
            _model.ValueChanged -= OnModelValueChanged;

        _model = model;
        _model.ValueChanged += OnModelValueChanged;
        OnModelValueChanged();
    }

    public abstract void OnModelValueChanged();
}